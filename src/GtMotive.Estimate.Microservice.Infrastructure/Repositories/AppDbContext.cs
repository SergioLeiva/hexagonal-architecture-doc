using System.Reflection;
using GtMotive.Estimate.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Rental> RentalsOperations { get; set; }

        public DbSet<Fleet> Fleets { get; set; }

        public void Seed()
        {
            Fleets.AddRange(
                new Fleet("SPORT"),
                new Fleet("ELECTRIC"),
                new Fleet("STANDARD"),
                new Fleet("LUXURY"),
                new Fleet("ECONOMIC"),
                new Fleet("TRANSPORT"));

            Vehicles.AddRange(
                new Vehicle("SPORT", "XYZ789", "BMW", 2023, false),
                new Vehicle("SPORT", "DEF456", "Polo", 2024, false),
                new Vehicle("ELECTRIC", "ABC123", "Tesla", 2022, false),
                new Vehicle("SPORT", "XYZ123", "Ford Mustang GT", 2024, false),
                new Vehicle("SPORT", "DEF456", "Chevrolet Camaro ZL1", 2023, false),
                new Vehicle("ELECTRIC", "ABC789", "Tesla Model 3", 2022, false),
                new Vehicle("ELECTRIC", "GHI012", "Hyundai Kona Electric", 2021, false),
                new Vehicle("STANDARD", "JKL345", "Toyota Camry", 2020, false),
                new Vehicle("STANDARD", "MNO678", "Honda Accord", 2019, false),
                new Vehicle("LUXURY", "PQR901", "Mercedes-Benz S-Class", 2023, false),
                new Vehicle("LUXURY", "STU234", "BMW 7 Series", 2022, false),
                new Vehicle("ECONOMIC", "VWX567", "Kia Rio", 2021, false),
                new Vehicle("ECONOMIC", "YZT890", "Nissan Versa", 2020, false),
                new Vehicle("TRANSPORT", "ABC123", "Ford F-150", 2023, false),
                new Vehicle("TRANSPORT", "DEF456", "Toyota RAV4", 2022, false));

            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is not null)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }
        }
    }
}
