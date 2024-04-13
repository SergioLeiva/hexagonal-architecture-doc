using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateFleet
{
    public class CreateVehicleResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleResponse"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the vehicle.</param>
        /// <param name="fleetName">The name of the associated fleet.</param>
        /// <param name="licencePlate">The licence plate of the vehicle.</param>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="manufacturingYear">The manufacturing year of the vehicle.</param>
        /// <param name="isRented">A value indicating whether the vehicle is rented.</param>
        public CreateVehicleResponse(Guid id, string fleetName, string licencePlate, string brand, int manufacturingYear, bool isRented)
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
        [Required]
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets  the name of the associated fleet.
        /// </summary>
        [Required]
        public string FleetName { get; private set; }

        /// <summary>
        /// Gets  the licence plate of the vehicle.
        /// </summary>
        [Required]
        public string LicencePlate { get; private set; }

        /// <summary>
        /// Gets  the brand of the vehicle.
        /// </summary>
        [Required]
        public string Brand { get; private set; }

        /// <summary>
        /// Gets  the manufacturing year of the vehicle.
        /// </summary>
        [Required]
        public int ManufacturingYear { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle is rented.
        /// </summary>
        [Required]
        public bool IsRented { get; set; }
    }
}
