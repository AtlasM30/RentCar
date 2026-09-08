using RentCar.Application.DTOs.Vehicle;
using RentCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Application.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<Vehicle> CreateAsync(CreateVehicleDTO dto);
        Task<List<Vehicle>> GetAllAsync();
        Task<Vehicle> GetByIdAsync(int id);
        Task<Vehicle> GetByPlacaAsync(string placa);
        Task<Vehicle> UpdateAsync(int id, UpdateVehicleDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
