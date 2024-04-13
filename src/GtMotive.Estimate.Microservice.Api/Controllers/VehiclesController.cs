using System;
using System.Net;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateFleet;
using GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehiclesAvailables;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehiclesController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        [SwaggerOperation("Create vehicle to the fleet.")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "")]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleRequest request)
        {
            if (request == null)
            {
                return BadRequest("Vehicle data is required.");
            }

            try
            {
                var presenter = await _mediator.Send(request);

                return presenter.ActionResult;
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{fleetName}/availables")]
        [SwaggerOperation("Get all vehicles availables.")]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(GetAllVehiclesAvailablesResponse))]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "")]
        public async Task<IActionResult> GetAvailables([FromRoute] string fleetName)
        {
            if (fleetName == null)
            {
                return BadRequest("FleetName data is required.");
            }

            try
            {
                var request = new GetAllVehiclesAvailablesRequest(fleetName);
                var presenter = await _mediator.Send(request);

                return Ok(presenter.ActionResult);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
