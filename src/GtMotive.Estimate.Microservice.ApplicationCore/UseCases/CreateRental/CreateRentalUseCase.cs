using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental
{
    /// <summary>
    /// Create Rental use case.
    /// </summary>
    public class CreateRentalUseCase : ICreateRentalUseCase
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICreateRentalOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRentalUseCase"/> class.
        /// </summary>
        /// <param name="rentalRepository">Rental repository.</param>
        /// <param name="vehicleRepository">Vehicle repository.</param>
        /// <param name="outputPort"> Output port.</param>
        public CreateRentalUseCase(IRentalRepository rentalRepository, IVehicleRepository vehicleRepository, ICreateRentalOutputPort outputPort)
        {
            _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">ArgumentNullException.</exception>
        /// <exception cref="InvalidOperationException">InvalidOperationException.</exception>
        public async Task Execute(CreateRentalInput input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input), "Input cannot be null.");
            }

            var hashActiveRental = await _rentalRepository.HashActive(input.ClientId);

            if (hashActiveRental)
            {
                throw new InvalidOperationException("The user has an active rental.");
            }

            var vehicle = await _vehicleRepository.GetVehicleByLicencePlate(input.VehicleLicencePlate);

            if (vehicle is null)
            {
                throw new InvalidOperationException("The vehicle dont exist.");
            }

            if (vehicle.IsRented)
            {
                throw new InvalidOperationException("The vehicle is rented");
            }

            var rental = new Rental(input.VehicleLicencePlate, input.ClientId);

            var addRentalTask = _rentalRepository.Add(rental);
            var updteVehicleTask = _vehicleRepository.ModifyVehicleRental(rental.VehicleLicencePlate, true);

            await Task.WhenAll(addRentalTask, updteVehicleTask);

            BuildOutput(rental);
        }

        private void BuildOutput(Rental rental)
        {
            var output = new CreateRentalOutput(rental.Id, rental.VehicleLicencePlate, rental.ClientId, rental.StartTime, rental.EndTime);
            _outputPort.StandardHandle(output);
        }
    }
}
