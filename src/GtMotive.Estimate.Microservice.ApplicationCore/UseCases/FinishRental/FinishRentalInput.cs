using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FinishRental
{
    /// <summary>
    /// Finisht Rental input.
    /// </summary>
    public class FinishRentalInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinishRentalInput"/> class.
        /// </summary>
        /// <param name="id">The id of the rental.</param>
        public FinishRentalInput(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets  the unique identifier of the rental.
        /// </summary>
        public Guid Id { get; private set; }
    }
}
