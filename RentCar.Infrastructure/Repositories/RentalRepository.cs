using Microsoft.EntityFrameworkCore;
using RentCar.Core.Entities;
using RentCar.Core.Repositories;
using RentCar.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Infrastructure.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly RentCarDbContext _context;

        public RentalRepository(RentCarDbContext context)
        {
            _context = context;
        }

        public async Task<Rental> CreateAsync(Rental rental)
        {
            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            return rental;
        }

        public async Task<List<Rental>> GetAllAsync()
        {
            return await _context.Rentals.Include(r => r.vehicle).ToListAsync();
        }

        public async Task<Rental?> GetByIdAsync(int id)
        {
            return await _context.Rentals.Include(r => r.vehicle).FirstOrDefaultAsync(r => r.id == id);
        }
        }
    }

