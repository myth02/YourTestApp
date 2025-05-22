using Microsoft.AspNetCore.Mvc;
using YourApp.DTO;
using YourApp.Services;

namespace YourApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthRequestDto dto)
        {
            var user = new User { Username = dto.Username };
            var token = await _authService.RegisterAsync(user, dto.Password);
            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequestDto dto)
        {
            var token = await _authService.LoginAsync(dto.Username, dto.Password);
            if (token == null) return Unauthorized();
            return Ok(new { Token = token });
        }
    }
}