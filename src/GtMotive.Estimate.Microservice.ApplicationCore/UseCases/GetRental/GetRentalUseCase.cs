using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetRental
{
    /// <summary>
    /// Create Vehicle use case.
    /// </summary>
    public class GetRentalUseCase : IGetRentalUseCase
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IGetRentalOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRentalUseCase"/> class.
        /// </summary>
        /// <param name="rentalRepository">Rental repository.</param>
        /// <param name="outputPort"> Output port.</param>
        public GetRentalUseCase(IRentalRepository rentalRepository, IGetRentalOutputPort outputPort)
        {
            _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">ArgumentNullException.</exception>
        /// <exception cref="InvalidOperationException">InvalidOperationException.</exception>
        public async Task Execute(GetRentalInput input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input), "Input cannot be null.");
            }

            BuildOutput(await _rentalRepository.GetById(input.Id) ?? throw new InvalidOperationException("There is no rental for that id"));
        }

        private void BuildOutput(Rental rental)
        {
            var output = new GetRentalOutput(rental.Id, rental.VehicleLicencePlate, rental.ClientId, rental.StartTime, rental.EndTime);
            _outputPort.StandardHandle(output);
        }
    }
}
