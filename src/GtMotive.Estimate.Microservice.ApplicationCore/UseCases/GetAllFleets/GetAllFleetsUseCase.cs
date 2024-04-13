using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllFleets
{
    /// <summary>
    /// Get all fleets use case.
    /// </summary>
    public class GetAllFleetsUseCase : IGetAllFleetsUseCase
    {
        private readonly IFleetRepository _fleetRepository;
        private readonly IGetAllFleetsOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllFleetsUseCase"/> class.
        /// </summary>
        /// <param name="fleetRepository">Fleet repository.</param>
        /// <param name="outputPort"> Output port.</param>
        public GetAllFleetsUseCase(IFleetRepository fleetRepository, IGetAllFleetsOutputPort outputPort)
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
        public async Task Execute(GetAllFleetsInput input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Input cannot be null.");
            }

            BuildOutput(await _fleetRepository.GetAllFleets());
        }

        private void BuildOutput(IEnumerable<Fleet> fleets)
        {
            var output = new GetAllFleetsOutput(fleets);
            _outputPort.StandardHandle(output);
        }
    }
}
