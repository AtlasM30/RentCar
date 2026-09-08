using RentCar.Application.DTOs.Rental;
using RentCar.Application.Services.Interfaces;
using RentCar.Core.Entities;
using RentCar.Core.Interfaces;
using RentCar.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Application.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RentalService(IRentalRepository rentalRepository, IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
        {
            _rentalRepository = rentalRepository;
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Rental?> CreateRentalAsync(CreateRentalDto dto)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var vehicle = await _vehicleRepository.GetByIdAsync(dto.vehicleId);

                if (vehicle == null)
                {
                    await _unitOfWork.RollbackAsync();
                    return null;
                }

                if (!vehicle.disponivel)
                {
                    await _unitOfWork.RollbackAsync();
                    return null;
                }

                if (dto.fimAluguel <= dto.inicioAluguel)
                {
                    await _unitOfWork.RollbackAsync();
                    return null;
                }

                vehicle.disponivel = false;

                await _vehicleRepository.UpdateAsync(dto.vehicleId, vehicle);

                var rental = new Rental
                {
                    nomeCliente = dto.nomeCliente,
                    inicioAluguel = dto.inicioAluguel,
                    fimAluguel = dto.fimAluguel,
                    vehicleId = dto.vehicleId
                };

                var createdRental = await _rentalRepository.CreateAsync(rental);

                await _unitOfWork.CommitAsync();

                return createdRental;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public Task<List<Rental>> GetAllRentalsAsync()
        {
           return _rentalRepository.GetAllAsync();
        }

        public Task<Rental?> GetRentalByIdAsync(int id)
        {
            return _rentalRepository.GetByIdAsync(id);
        }
    }
}
