using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Extensions;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;
using GtMotive.Estimate.Microservice.ApplicationCore.Validations.Vehicle;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Create Vehicle use case.
    /// </summary>
    public class CreateVehicleUseCase : ICreateVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleValidationService _vehicleValidationService;
        private readonly ICreateVehicleOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">Vehicle repository.</param>
        /// <param name="vehicleValidationService">Vehicle validation service.</param>
        /// <param name="outputPort">Output port.</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException.</exception>
        public CreateVehicleUseCase(IVehicleRepository vehicleRepository, IVehicleValidationService vehicleValidationService, ICreateVehicleOutputPort outputPort)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _vehicleValidationService = vehicleValidationService ?? throw new ArgumentNullException(nameof(vehicleValidationService));
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">ArgumentNullException.</exception>
        /// <exception cref="InvalidOperationException">InvalidOperationException.</exception>
        public async Task Execute(CreateVehicleInput input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Input cannot be null.");
            }

            var vehicleExist = await _vehicleRepository.GetVehicleByLicencePlate(input.LicencePlate.UpperClean());
            if (vehicleExist is not null)
            {
                throw new ArgumentException("The vehicle already exists");
            }

            if (!_vehicleValidationService.ManufacturingDateValid(input.ManufacturingYear))
            {
                throw new ArgumentException("Manufactured date is not valid, mast be within the last 5 years.", nameof(input));
            }

            var vehicle = new Vehicle(input.FleetName.UpperClean(), input.LicencePlate.UpperClean(), input.Brand, input.ManufacturingYear, input.IsRented);

            await _vehicleRepository.AddVehicle(vehicle);

            BuildOutput(vehicle);
        }

        private void BuildOutput(Vehicle vehicle)
        {
            var output = new CreateVehicleOutput(vehicle.Id, vehicle.FleetName, vehicle.LicencePlate, vehicle.Brand, vehicle.ManufacturingYear, vehicle.IsRented);
            _outputPort.StandardHandle(output);
        }
    }
}
