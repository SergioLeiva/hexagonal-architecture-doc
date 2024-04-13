using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;
using GtMotive.Estimate.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _context;

        public VehicleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesByFleet(string fleetName)
        {
            return await _context.Vehicles.Where(vehicle => vehicle.FleetName.ToUpperInvariant().Trim() == fleetName.ToUpperInvariant().Trim()).ToListAsync();
        }

        public async Task<Vehicle> GetVehicleByLicencePlate(string licencePlate)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(vehicle => vehicle.LicencePlate.ToUpperInvariant().Trim() == licencePlate.ToUpperInvariant().Trim());
        }

        public async Task ModifyVehicleRental(string licencePlate, bool isRental)
        {
            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(vehicle => vehicle.LicencePlate.ToUpperInvariant().Trim() == licencePlate.ToUpperInvariant().Trim());
            if (vehicle != null)
            {
                _context.Entry(vehicle).Entity.IsRented = isRental;
                _context.Entry(vehicle).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
