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
        public async Task<IActionResult> Register(User user, string password)
        {
            var token = await _authService.RegisterAsync(user, password);
            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var token = await _authService.LoginAsync(username, password);
            if (token == null) return Unauthorized();
            return Ok(new { Token = token });
        }
    }
}