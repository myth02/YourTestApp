using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using YourApp.DTO;
using YourApp.Services;

namespace YourApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformService _service;

        public PlatformsController(IPlatformService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlatformDto dto) => Ok(await _service.CreateAsync(dto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PlatformDto dto) =>
            await _service.UpdateAsync(id, dto) ? Ok() : NotFound();

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            await _service.DeleteAsync(id) ? Ok() : NotFound();
    }
}
