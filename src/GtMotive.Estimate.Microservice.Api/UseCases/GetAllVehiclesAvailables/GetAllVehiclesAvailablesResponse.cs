using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehiclesAvailables
{
    public class GetAllVehiclesAvailablesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllVehiclesAvailablesResponse"/> class.
        /// </summary>
        /// <param name="vehicles">Input vehicles.</param>
        public GetAllVehiclesAvailablesResponse(IEnumerable<VehicleDto> vehicles)
        {
            Vechicles = vehicles;
        }

        [Required]
        public IEnumerable<VehicleDto> Vechicles { get; private set; }
    }
}
