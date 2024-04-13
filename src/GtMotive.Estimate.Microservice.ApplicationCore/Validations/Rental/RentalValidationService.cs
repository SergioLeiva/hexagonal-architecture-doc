using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Validations
{
    /// <summary>
    /// Validations for the rental.
    /// </summary>
    public class RentalValidationService : IRentalValidationService
    {
        private readonly IRentalRepository _rentalRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalValidationService"/> class.
        /// </summary>
        /// <param name="rentalRepository">The rental repository.</param>
        public RentalValidationService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        /// <inheritdoc/>
        public async Task<bool> UserHashActivateRental(string userId)
        {
            return await _rentalRepository.HashActive(userId);
        }
    }
}
