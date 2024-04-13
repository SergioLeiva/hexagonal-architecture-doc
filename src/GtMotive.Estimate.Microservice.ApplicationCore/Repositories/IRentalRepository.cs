using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Repositories
{
    /// <summary>
    /// Interface interface responsible for managing rental data.
    /// </summary>
    public interface IRentalRepository
    {
        /// <summary>
        /// Add new rental to the repository.
        /// </summary>
        /// <param name="rental">The rental to be added.</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task Add(Rental rental);

        /// <summary>
        /// Complete a rental, given its the unique identifier.
        /// </summary>
        /// <param name="rentalId"> The unique identifier of the rental.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Finish(Guid rentalId);

        /// <summary>
        /// Check if the client has an active rental.
        /// </summary>
        /// <param name="clientId"> The unique identifier of the client.</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task<bool> HashActive(string clientId);

        /// <summary>
        /// Check if the client has an active rental.
        /// </summary>
        /// <param name="rentalId"> The unique identifier of the rental.</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task<Rental> GetById(Guid rentalId);
    }
}
