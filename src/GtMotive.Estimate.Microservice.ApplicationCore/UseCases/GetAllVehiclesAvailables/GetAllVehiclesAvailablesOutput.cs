using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehiclesAvailables
{
    /// <summary>
    /// Get all vehicles availables output.
    /// </summary>
    public class GetAllVehiclesAvailablesOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllVehiclesAvailablesOutput"/> class.
        /// </summary>
        /// <param name="vehicles">Vehicles input.</param>
        public GetAllVehiclesAvailablesOutput(IEnumerable<Vehicle> vehicles)
        {
            Vehicles = vehicles;
        }

        /// <summary>
        /// Gets fleets.
        /// </summary>
        public IEnumerable<Vehicle> Vehicles { get; private set; }
    }
}
