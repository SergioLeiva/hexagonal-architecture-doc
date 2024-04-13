using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetRental
{
    /// <summary>
    /// Get rental input.
    /// </summary>
    public class GetRentalInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetRentalInput"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the rental.</param>
        public GetRentalInput(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets unique identifier of the fleet.
        /// </summary>
        public Guid Id { get; private set; }
    }
}
