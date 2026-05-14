using Microsoft.AspNetCore.Mvc;
using UserService.DTOs;
using UserService.Services;
using Microsoft.AspNetCore.Authorization;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _service.Register(registerDto);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _service.Login(loginDto);

            return Ok(token);

        }
        [Authorize]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Protected API Accessed");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult AdminOnly()
        {
            return Ok("Welcome Admin");
        }
    }
}