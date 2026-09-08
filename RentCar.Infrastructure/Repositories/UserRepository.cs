using RentCar.Core.Entities;
using RentCar.Core.Repositories;
using RentCar.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RentCarDbContext _context;

        public UserRepository(RentCarDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> GetByUsernameAsync(string nomeUsuario)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.nomeUsuario == nomeUsuario);
        }
    }
}
