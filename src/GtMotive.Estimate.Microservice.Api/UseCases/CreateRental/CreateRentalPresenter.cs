using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateRental
{
    public class CreateRentalPresenter : ICreateRentalPresenter, ICreateRentalOutputPort
    {
        public IActionResult ActionResult
        {
            get;
            private set;
        }

        public void StandardHandle(CreateRentalOutput response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var viewModel = new CreateRentalResponse(response.Id, response.VehicleLicencePlate, response.ClientId, response.StartTime, response.EndTime);
            ActionResult = new OkObjectResult(viewModel);
        }
    }
}
