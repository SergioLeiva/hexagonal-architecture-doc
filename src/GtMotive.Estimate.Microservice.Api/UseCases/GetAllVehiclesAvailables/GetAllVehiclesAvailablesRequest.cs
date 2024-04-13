using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehiclesAvailables
{
    public record class GetAllVehiclesAvailablesRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllVehiclesAvailablesRequest"/> class.
        /// </summary>
        /// <param name="fleetName">Input value fleetName.</param>
        public GetAllVehiclesAvailablesRequest(string fleetName)
        {
            FleetName = fleetName;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        [Required]
        public string FleetName { get; private set; }
    }
}
