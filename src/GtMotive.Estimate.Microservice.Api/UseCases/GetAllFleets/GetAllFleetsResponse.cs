using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllFleets
{
    public class GetAllFleetsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllFleetsResponse"/> class.
        /// </summary>
        /// <param name="fleets">Input fleets.</param>
        public GetAllFleetsResponse(IEnumerable<FleetDto> fleets)
        {
            Fleets = fleets;
        }

        public IEnumerable<FleetDto> Fleets { get; private set; }
    }
}
