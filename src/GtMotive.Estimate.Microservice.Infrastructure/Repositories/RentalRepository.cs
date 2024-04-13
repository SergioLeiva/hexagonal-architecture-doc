using System;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;
using GtMotive.Estimate.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly AppDbContext _context;

        public RentalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Rental rental)
        {
            _context.RentalsOperations.Add(rental);
            await _context.SaveChangesAsync();
        }

        public async Task Finish(Guid rentalId)
        {
            var rental = await _context.RentalsOperations.FirstOrDefaultAsync(rental => rental.Id == rentalId);
            if (rental != null)
            {
                _context.Entry(rental).Entity.EndTime = DateTime.Now;
                _context.Entry(rental).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Rental> GetById(Guid rentalId)
        {
            return await _context.RentalsOperations.FirstOrDefaultAsync(rental => rental.Id == rentalId);
        }

        public async Task<bool> HashActive(string clientId)
        {
            return await _context.RentalsOperations.Where(rental => rental.ClientId.ToUpperInvariant().Trim() == clientId.ToUpperInvariant().Trim() && rental.EndTime != null).AnyAsync();
        }
    }
}
