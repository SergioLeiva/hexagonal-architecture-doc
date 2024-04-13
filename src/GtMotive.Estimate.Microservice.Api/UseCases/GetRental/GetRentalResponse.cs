using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetRental
{
    public class GetRentalResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetRentalResponse"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the rental.</param>
        /// <param name="vehicleLicencePlate">The vehicle licence plate of the rented vehicle.</param>
        /// <param name="clientId">The client`s identification associated with the rental.</param>
        /// <param name="startTime">The start of the rental period.</param>
        /// <param name="endTime">The end of the rental period.</param>
        public GetRentalResponse(Guid id, string vehicleLicencePlate, string clientId, DateTime startTime, DateTime? endTime)
        {
            Id = id;
            VehicleLicencePlate = vehicleLicencePlate;
            ClientId = clientId;
            StartTime = startTime;
            EndTime = endTime;
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
        /// Gets  the end of the rental period.
        /// </summary>
        public DateTime? EndTime { get; private set; }
    }
}
