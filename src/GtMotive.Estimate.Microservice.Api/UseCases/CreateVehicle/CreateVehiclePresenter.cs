using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateFleet
{
    public class CreateVehiclePresenter : ICreateVehiclePresenter, ICreateVehicleOutputPort
    {
        public IActionResult ActionResult
        {
            get;
            private set;
        }

        public void StandardHandle(CreateVehicleOutput response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var viewModel = new CreateVehicleResponse(response.Id, response.FleetName, response.LicencePlate, response.Brand, response.ManufacturingYear, response.IsRented);
            ActionResult = new OkObjectResult(viewModel);
        }
    }
}
