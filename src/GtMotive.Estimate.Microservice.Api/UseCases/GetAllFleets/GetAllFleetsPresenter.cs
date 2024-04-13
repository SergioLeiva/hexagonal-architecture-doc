using System;
using System.Linq;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllFleets;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllFleets
{
    public class GetAllFleetsPresenter : IGetAllFleetsPresenter, IGetAllFleetsOutputPort
    {
        public IActionResult ActionResult
        {
            get;
            private set;
        }

        public void StandardHandle(GetAllFleetsOutput response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var viewModel = new GetAllFleetsResponse(response.Fleets.Select(fleet => new FleetDto(fleet.Id, fleet.Name)));
            ActionResult = new OkObjectResult(viewModel);
        }
    }
}
