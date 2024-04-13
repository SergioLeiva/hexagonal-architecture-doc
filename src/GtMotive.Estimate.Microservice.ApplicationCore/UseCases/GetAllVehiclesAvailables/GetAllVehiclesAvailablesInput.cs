namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehiclesAvailables
{
    /// <summary>
    /// Get all vehicles availables input.
    /// </summary>
    public class GetAllVehiclesAvailablesInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllVehiclesAvailablesInput"/> class.
        /// </summary>
        /// <param name="fleetName">Input value fleetName.</param>
        public GetAllVehiclesAvailablesInput(string fleetName)
        {
            FleetName = fleetName;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string FleetName { get; private set; }
    }
}
