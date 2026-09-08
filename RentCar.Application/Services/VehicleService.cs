using RentCar.Application.DTOs.Vehicle;
using RentCar.Application.Services.Interfaces;
using RentCar.Core.Entities;
using RentCar.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<Vehicle> CreateAsync(CreateVehicleDTO dto)
        {
            var vehicle = new Vehicle
            {
                marca = dto.marca,
                modelo = dto.modelo,
                ano = dto.ano,
                placa = dto.placa,
                valorDiaria = dto.valorDiaria,
                disponivel = true
            };

            return await _vehicleRepository.CreateAsync(vehicle);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);

            if (vehicle == null)
                return false;

            await _vehicleRepository.DeleteAsync(vehicle);
            
            return true;
        }

        public async Task<List<Vehicle>> GetAllAsync()
        {
            return await _vehicleRepository.GetAllAsync();
        }

        public async Task<Vehicle> GetByIdAsync(int id)
        {
            return await _vehicleRepository.GetByIdAsync(id);
        }

        public async Task<Vehicle> GetByPlacaAsync(string placa)
        {
            return await _vehicleRepository.GetByPlacaAsync(placa);
        }

        public async Task<Vehicle> UpdateAsync(int id, UpdateVehicleDTO dto)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);

            if (vehicle == null)
                return null;

            vehicle.marca = dto.marca;
            vehicle.modelo = dto.modelo;
            vehicle.ano = dto.ano;
            vehicle.placa = dto.placa;
            vehicle.valorDiaria = dto.valorDiaria;

            return await _vehicleRepository.UpdateAsync(id, vehicle);
        }
    }
}
