using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AirlineManagementSystem.Data;

namespace AirlineManagementSystem.Data
{
    public class AirlineDbContextFactory : IDesignTimeDbContextFactory<AirlineDbContext>
    {
        public AirlineDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AirlineDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new AirlineDbContext(optionsBuilder.Options);
        }
    }
}