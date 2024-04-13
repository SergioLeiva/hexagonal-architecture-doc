using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Validations
{
    /// <summary>
    /// Interface with validations for the rental.
    /// </summary>
    public interface IRentalValidationService
    {
        /// <summary>
        /// Validation if the user hash an active rental.
        /// </summary>
        /// <param name="userId"> Tue user id.</param>
        /// <returns>A boolean indicating if the user hash an activate rental.</returns>
        public Task<bool> UserHashActivateRental(string userId);
    }
}
