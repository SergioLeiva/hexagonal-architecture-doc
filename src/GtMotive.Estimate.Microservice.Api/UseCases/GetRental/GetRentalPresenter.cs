using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetRental;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetRental
{
    public class GetRentalPresenter : IGetRentalPresenter, IGetRentalOutputPort
    {
        public IActionResult ActionResult
        {
            get;
            private set;
        }

        public void StandardHandle(GetRentalOutput response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var viewModel = new GetRentalResponse(response.Id, response.VehicleLicencePlate, response.ClientId, response.StartTime, response.EndTime);
            ActionResult = new OkObjectResult(viewModel);
        }
    }
}
