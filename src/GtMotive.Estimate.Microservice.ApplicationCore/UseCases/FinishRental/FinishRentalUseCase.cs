using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FinishRental
{
    /// <summary>
    /// Create Vehicle use case.
    /// </summary>
    public class FinishRentalUseCase : IFinishRentalUseCase
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IFinishRentalOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinishRentalUseCase"/> class.
        /// </summary>
        /// <param name="rentalRepository">Rental repository.</param>
        /// <param name="vehicleRepository">Vehicle repository.</param>
        /// <param name="outputPort">Output port.</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException.</exception>
        public FinishRentalUseCase(IRentalRepository rentalRepository, IVehicleRepository vehicleRepository, IFinishRentalOutputPort outputPort)
        {
            _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">ArgumentNullException.</exception>
        /// <exception cref="InvalidOperationException">InvalidOperationException.</exception>
        public async Task Execute(FinishRentalInput input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Input cannot be null.");
            }

            var rental = await _rentalRepository.GetById(input.Id) ?? throw new InvalidOperationException("There is no rental for that id");

            if (rental.EndTime != null)
            {
                throw new InvalidOperationException("The rental is already finished.");
            }

            var finishTask = _rentalRepository.Finish(input.Id);
            var updteVehicleTask = _vehicleRepository.ModifyVehicleRental(rental.VehicleLicencePlate, true);

            await Task.WhenAll(finishTask, updteVehicleTask);

            BuildOutput(rental);
        }

        private void BuildOutput(Rental rental)
        {
            var output = new FinishRentalOutput(rental.Id, rental.VehicleLicencePlate, rental.ClientId, rental.StartTime, rental.EndTime);
            _outputPort.StandardHandle(output);
        }
    }
}
