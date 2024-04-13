using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represent a rental of a vehicle.
    /// </summary>
    public class Rental
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rental"/> class.
        /// </summary>
        /// <param name="vehicleLicencePlate">The vehicle licence plate of the rented vehicle.</param>
        /// <param name="clientId">The client`s identification associated with the rental.</param>
        /// <param name="startTime">The start of the rental period.</param>
        /// <param name="endTime">The end of the rental period.</param>
        public Rental(string vehicleLicencePlate, string clientId)
        {
            Id = Guid.NewGuid();
            VehicleLicencePlate = vehicleLicencePlate;
            ClientId = clientId;
            StartTime = DateTime.Now;
            EndTime = null;
        }

        /// <summary>
        /// Gets the unique idenfier of the rental.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the vehicle licence plate.
        /// </summary>
        public string VehicleLicencePlate { get; private set; }

        /// <summary>
        /// Gets the client`s identification associated with the rental.
        /// </summary>
        public string ClientId { get; private set; }

        /// <summary>
        /// Gets the start of the rental period.
        /// </summary>
        public DateTime StartTime { get; private set; }

        /// <summary>
        /// Gets or Sets the end of the rental period.
        /// </summary>
        public DateTime? EndTime { get; set; }
    }
}
