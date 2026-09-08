using Microsoft.EntityFrameworkCore.Storage;
using RentCar.Core.Interfaces;
using RentCar.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentCarDbContext _context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(RentCarDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }
        }
    }
}
