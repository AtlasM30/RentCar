using RentCar.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterUserDto dto);
        Task<string?> LoginAsync(LoginDto dto);
    }
}
