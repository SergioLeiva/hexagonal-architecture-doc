using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;
using GtMotive.Estimate.Microservice.ApplicationCore.Validations.Vehicle;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehiclesAvailables
{
    /// <summary>
    /// Get all vehicles availables use case.
    /// </summary>
    public class GetAllVehiclesAvailablesUseCase : IGetAllVehiclesAvailablesUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IGetAllVehiclesAvailablesOutputPort _outputPort;
        private readonly IVehicleValidationService _vehicleValidationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllVehiclesAvailablesUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">Vehicle repository.</param>
        /// <param name="outputPort">Output port.</param>
        /// <param name="vehicleValidationService">Vechicle validation.</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException.</exception>
        public GetAllVehiclesAvailablesUseCase(IVehicleRepository vehicleRepository, IGetAllVehiclesAvailablesOutputPort outputPort, IVehicleValidationService vehicleValidationService)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
            _vehicleValidationService = vehicleValidationService ?? throw new ArgumentNullException(nameof(vehicleValidationService));
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">ArgumentNullException.</exception>
        public async Task Execute(GetAllVehiclesAvailablesInput input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Input cannot be null.");
            }

            var vehicles = await _vehicleRepository.GetAllVehiclesByFleet(input.FleetName);

            BuildOutput(vehicles.Where(vehicle => _vehicleValidationService.ManufacturingDateValid(vehicle.ManufacturingYear)));
        }

        private void BuildOutput(IEnumerable<Vehicle> vehicles)
        {
            var output = new GetAllVehiclesAvailablesOutput(vehicles);
            _outputPort.StandardHandle(output);
        }
    }
}
