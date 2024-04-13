using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllFleets
{
    /// <summary>
    /// Get all flests output.
    /// </summary>
    public class GetAllFleetsOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllFleetsOutput"/> class.
        /// </summary>
        /// <param name="fleets">Fleets input.</param>
        public GetAllFleetsOutput(IEnumerable<Fleet> fleets)
        {
            Fleets = fleets;
        }

        /// <summary>
        /// Gets fleets.
        /// </summary>
        public IEnumerable<Fleet> Fleets { get; private set; }
    }
}
