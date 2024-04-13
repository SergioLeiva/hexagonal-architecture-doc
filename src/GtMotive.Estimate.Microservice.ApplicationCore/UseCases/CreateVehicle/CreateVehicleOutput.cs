using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Create Vehicle output.
    /// </summary>
    public class CreateVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleOutput"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the vehicle.</param>
        /// <param name="fleetName">The name of the associated fleet.</param>
        /// <param name="licencePlate">The licence plate of the vehicle.</param>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="manufacturingYear">The manufacturing year of the vehicle.</param>
        /// <param name="isRented">A value indicating whether the vehicle is rented.</param>
        public CreateVehicleOutput(Guid id, string fleetName, string licencePlate, string brand, int manufacturingYear, bool isRented)
        {
            Id = id;
            FleetName = fleetName;
            LicencePlate = licencePlate;
            Brand = brand;
            ManufacturingYear = manufacturingYear;
            IsRented = isRented;
        }

        /// <summary>
        /// Gets the unique identifier of the vehicle.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets  the name of the associated fleet.
        /// </summary>
        public string FleetName { get; private set; }

        /// <summary>
        /// Gets  the licence plate of the vehicle.
        /// </summary>
        public string LicencePlate { get; private set; }

        /// <summary>
        /// Gets  the brand of the vehicle.
        /// </summary>
        public string Brand { get; private set; }

        /// <summary>
        /// Gets  the manufacturing year of the vehicle.
        /// </summary>
        public int ManufacturingYear { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle is rented.
        /// </summary>
        public bool IsRented { get; set; }
    }
}
