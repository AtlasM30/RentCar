using RentCar.Core.Entities;
using RentCar.Core.Repositories;
using RentCar.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly RentCarDbContext _context;

        public VehicleRepository(RentCarDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> CreateAsync(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task<List<Vehicle>> GetAllAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle?> GetByIdAsync(int id)
        {
            return await _context.Vehicles.FindAsync(id);
        }

        public async Task<Vehicle?> GetByPlacaAsync(string placa) 
        {
            return await _context.Vehicles.FirstOrDefaultAsync(v => v.placa == placa);
        }

        public async Task<Vehicle> UpdateAsync(int id, Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task DeleteAsync(Vehicle vehicle)
        {
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
        }

    }
}
