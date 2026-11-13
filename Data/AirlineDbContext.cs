using Microsoft.EntityFrameworkCore;
using AirlineManagementSystem.Models;

namespace AirlineManagementSystem.Data
{
    public class AirlineDbContext : DbContext
    {
        public DbSet<Passageiro> Passageiros { get; set; } = null!;
        public DbSet<Voo> Voos { get; set; } = null!;
        public DbSet<Aeronave> Aeronaves { get; set; } = null!;
        public DbSet<Reserva> Reservas { get; set; } = null!;

        public AirlineDbContext(DbContextOptions<AirlineDbContext> options)
            : base(options)
        {
        }

    }
}

