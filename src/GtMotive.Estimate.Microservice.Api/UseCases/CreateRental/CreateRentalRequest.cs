using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateRental
{
    public record class CreateRentalRequest : IRequest<IWebApiPresenter>
    {
        public CreateRentalRequest(string vehicleLicencePlate, string clientId)
        {
            VehicleLicencePlate = vehicleLicencePlate;
            ClientId = clientId;
        }

        /// <summary>
        /// Gets the vehicle licence plate.
        /// </summary>
        [Required]
        public string VehicleLicencePlate { get; private set; }

        /// <summary>
        /// Gets the client`s identification associated with the rental.
        /// </summary>
        [Required]
        public string ClientId { get; private set; }
    }
}
