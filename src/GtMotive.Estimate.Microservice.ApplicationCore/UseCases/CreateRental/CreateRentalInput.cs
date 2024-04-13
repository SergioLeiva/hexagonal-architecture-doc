namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental
{
    /// <summary>
    /// Create rental input.
    /// </summary>
    public class CreateRentalInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRentalInput"/> class.
        /// </summary>
        /// <param name="vehicleLicencePlate">The vehicle licence plate of the rented vehicle.</param>
        /// <param name="clientId">The client`s identification associated with the rental.</param>
        public CreateRentalInput(string vehicleLicencePlate, string clientId)
        {
            VehicleLicencePlate = vehicleLicencePlate;
            ClientId = clientId;
        }

        /// <summary>
        /// Gets the vehicle licence plate.
        /// </summary>
        public string VehicleLicencePlate { get; private set; }

        /// <summary>
        /// Gets the client`s identification associated with the rental.
        /// </summary>
        public string ClientId { get; private set; }
    }
}
