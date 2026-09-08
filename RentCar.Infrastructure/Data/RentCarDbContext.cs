using Microsoft.EntityFrameworkCore;
using RentCar.Core.Entities;

namespace RentCar.Infrastructure.Data
{
    public class RentCarDbContext : DbContext
    {
        public RentCarDbContext(DbContextOptions<RentCarDbContext> options) : base(options)
        {
        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.placa)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.nomeUsuario)
                .IsUnique();
        }
    }
}
