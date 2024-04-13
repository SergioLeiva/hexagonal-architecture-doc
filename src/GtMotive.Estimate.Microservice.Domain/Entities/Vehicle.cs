using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represent a vehicle.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="fleetName">The name of the associated fleet.</param>
        /// <param name="licencePlate">The licence plate of the vehicle.</param>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="manufacturingYear">The manufacturing year of the vehicle.</param>
        /// <param name="isRented">A value indicating whether the vehicle is rented.</param>
        public Vehicle(string fleetName, string licencePlate, string brand, int manufacturingYear, bool isRented)
        {
            Id = Guid.NewGuid();
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
        /// Gets or sets the name of the associated fleet.
        /// </summary>
        public string FleetName { get; set; }

        /// <summary>
        /// Gets or sets the licence plate of the vehicle.
        /// </summary>
        public string LicencePlate { get; set; }

        /// <summary>
        /// Gets or sets the brand of the vehicle.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the manufacturing year of the vehicle.
        /// </summary>
        public int ManufacturingYear { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle is rented.
        /// </summary>
        public bool IsRented { get; set; }
    }
}
