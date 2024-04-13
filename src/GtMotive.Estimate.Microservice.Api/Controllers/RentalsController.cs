using System;
using System.Net;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateRental;
using GtMotive.Estimate.Microservice.Api.UseCases.FinishRental;
using GtMotive.Estimate.Microservice.Api.UseCases.GetRental;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentalsController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [SwaggerOperation("Create a new Rental.")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Rental created", typeof(CreateRentalResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Rental not created")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Rental not created")]
        public async Task<IActionResult> CreateRental([FromBody] CreateRentalRequest request)
        {
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

        [HttpPut("finish/{id}")]
        [SwaggerOperation("Rental ends.")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Rental created", typeof(FinishRentalResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Unfinished rental")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Unfinished rental")]
        public async Task<IActionResult> FinishRental([FromRoute] Guid id)
        {
            try
            {
                var request = new FinishRentalRequest(id);
                var presenter = await _mediator.Send(request);

                return presenter.ActionResult;
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Get rental by id.")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Rental ok", typeof(GetRentalResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Unfinished rental")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Unfinished rental")]
        public async Task<IActionResult> GetRental([FromRoute] Guid id)
        {
            try
            {
                var request = new GetRentalRequest(id);
                var presenter = await _mediator.Send(request);

                return presenter.ActionResult;
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
