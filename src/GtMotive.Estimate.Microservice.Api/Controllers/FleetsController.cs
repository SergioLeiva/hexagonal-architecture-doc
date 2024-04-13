using System;
using System.Net;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateFleet;
using GtMotive.Estimate.Microservice.Api.UseCases.GetAllFleets;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FleetsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FleetsController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        [SwaggerOperation("Add a fleet.")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "")]
        public async Task<IActionResult> AddFleet([FromBody] CreateFleetRequest request)
        {
            if (request == null)
            {
                return BadRequest("Fleet data is required.");
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

        [HttpGet("")]
        [SwaggerOperation("Get all fleets.")]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(GetAllFleetsResponse))]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "")]
        public async Task<IActionResult> GetAllFleets()
        {
            try
            {
                var presenter = await _mediator.Send(new GetAllFleetsRequest());

                return presenter.ActionResult;
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
