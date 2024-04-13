using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FinishRental;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.FinishRental
{
    public class FinishRentalPresenter : IFinishRentalPresenter, IFinishRentalOutputPort
    {
        public IActionResult ActionResult
        {
            get;
            private set;
        }

        public void StandardHandle(FinishRentalOutput response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var viewModel = new FinishRentalResponse(response.Id, response.VehicleLicencePlate, response.ClientId, response.StartTime, response.EndTime);
            ActionResult = new OkObjectResult(viewModel);
        }
    }
}
