using RentCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Core.Repositories
{
    public interface IVehicleRepository
    {
        Task<Vehicle> CreateAsync(Vehicle vehicle);
        Task<List<Vehicle>> GetAllAsync();
        Task<Vehicle?> GetByIdAsync(int id);
        Task<Vehicle?> GetByPlacaAsync(string placa);
        Task<Vehicle> UpdateAsync(int id, Vehicle vehicle);
        Task DeleteAsync(Vehicle vehicle);
    }
}
