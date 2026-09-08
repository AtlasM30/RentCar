using RentCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Core.Repositories
{
    public interface IRentalRepository
    {
        Task<Rental> CreateAsync(Rental rental);
        Task<List<Rental>> GetAllAsync();
        Task<Rental?> GetByIdAsync(int id);
    }
}
