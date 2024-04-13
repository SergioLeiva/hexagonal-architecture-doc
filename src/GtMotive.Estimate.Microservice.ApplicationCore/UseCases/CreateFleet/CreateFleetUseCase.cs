using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Extensions;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateFleet
{
    /// <summary>
    /// Create fleet use case.
    /// </summary>
    public class CreateFleetUseCase : ICreateFleetUseCase
    {
        private readonly IFleetRepository _fleetRepository;
        private readonly ICreateFleetOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFleetUseCase"/> class.
        /// </summary>
        /// <param name="fleetRepository">Fleet repository.</param>
        /// <param name="outputPort"> Output port.</param>
        public CreateFleetUseCase(IFleetRepository fleetRepository, ICreateFleetOutputPort outputPort)
        {
            _fleetRepository = fleetRepository ?? throw new ArgumentNullException(nameof(fleetRepository));
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">ArgumentNullException.</exception>
        /// <exception cref="InvalidOperationException">InvalidOperationException.</exception>
        public async Task Execute(CreateFleetInput input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Fleet cannot be null.");
            }

            var fleet = new Fleet(input.Name.UpperClean());

            var fleetByName = await _fleetRepository.GetFleetByName(fleet.Name);

            if (fleetByName is not null)
            {
                throw new InvalidOperationException("The fleet already exists");
            }

            await _fleetRepository.AddFleet(fleet);

            BuildOutput(fleet);
        }

        private void BuildOutput(Fleet fleet)
        {
            var output = new CreateFleetOutput(fleet.Id, fleet.Name);
            _outputPort.StandardHandle(output);
        }
    }
}
