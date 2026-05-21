using FitnessAPI.DTOs;
using FitnessAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var result =
                await _service.RegisterAsync(dto);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var token =
                await _service.LoginAsync(dto);

            if (token == null)
            {
                return Unauthorized(
                    "Invalid Email or Password");
            }

            return Ok(token);
        }
        [Authorize]
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            return Ok("Protected API Accessed Successfully");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult AdminOnly()
        {
            return Ok("Only Admin Can Access");
        }
         
    }
}