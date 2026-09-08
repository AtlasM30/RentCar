using Microsoft.Extensions.Configuration;
using RentCar.Application.DTOs.Auth;
using RentCar.Application.Services.Interfaces;
using RentCar.Core.Entities;
using RentCar.Core.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RentCar.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByUsernameAsync(dto.nomeUsuario);

            if (user == null)
                return null;

            var senhaValida = BCrypt.Net.BCrypt.Verify(dto.senha, user.senhaHash);

            if (!senhaValida)
                return null;

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.nomeUsuario),
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
            );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> RegisterAsync(RegisterUserDto dto)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(dto.nomeUsuario);

            if (existingUser != null)
                return false;

            var user = new User
            {
                nomeUsuario = dto.nomeUsuario,
                senhaHash = BCrypt.Net.BCrypt.HashPassword(dto.senha)
            };

            await _userRepository.CreateUserAsync(user);
            return true;
        }
    }
}
