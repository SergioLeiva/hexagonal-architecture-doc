using System;
using System.Linq;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehiclesAvailables;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehiclesAvailables
{
    public class GetAllVehiclesAvailablesPresenter : IGetAllVehiclesAvailablesPresenter, IGetAllVehiclesAvailablesOutputPort
    {
        public IActionResult ActionResult
        {
            get;
            private set;
        }

        public void StandardHandle(GetAllVehiclesAvailablesOutput response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var viewModel = new GetAllVehiclesAvailablesResponse(response.Vehicles.Select(vehicle => new VehicleDto(vehicle.Id, vehicle.FleetName, vehicle.LicencePlate, vehicle.Brand, vehicle.ManufacturingYear, vehicle.IsRented)));
            ActionResult = new OkObjectResult(viewModel);
        }
    }
}
