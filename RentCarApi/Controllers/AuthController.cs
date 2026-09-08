using Microsoft.AspNetCore.Mvc;
using RentCar.Application.DTOs.Auth;
using RentCar.Application.Services.Interfaces;

namespace RentCarApi.Controllers
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
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            var result = await _authService.RegisterAsync(dto);
            
            if (!result)
                return BadRequest("Usuário já existe");

            return Ok("Usuário registrado com sucesso");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            
            if (result == null)
                return Unauthorized("Credenciais inválidas");
            return Ok(new { token = result });
        }
    }
}
