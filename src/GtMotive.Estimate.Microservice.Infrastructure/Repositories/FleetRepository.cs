using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;
using GtMotive.Estimate.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class FleetRepository : IFleetRepository
    {
        private readonly AppDbContext _context;

        public FleetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddFleet(Fleet fleet)
        {
            _context.Fleets.Add(fleet);
            await _context.SaveChangesAsync();
        }

        public async Task<Fleet> GetFleetByName(string name)
        {
            return await _context.Fleets.FirstOrDefaultAsync(fleet => fleet.Name.ToUpperInvariant().Trim() == name.ToUpperInvariant().Trim());
        }

        public async Task<IEnumerable<Fleet>> GetAllFleets()
        {
            return await _context.Fleets.ToListAsync();
        }
    }
}
