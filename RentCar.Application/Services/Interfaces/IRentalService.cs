using RentCar.Application.DTOs.Rental;
using RentCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Application.Services.Interfaces
{
    public interface IRentalService
    {
        Task<Rental?> CreateRentalAsync(CreateRentalDto dto);
        Task<List<Rental>> GetAllRentalsAsync();
        Task<Rental?> GetRentalByIdAsync(int id);
    }
}
