using RentCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<User?> GetByUsernameAsync(string nomeUsuario);
    }
}
