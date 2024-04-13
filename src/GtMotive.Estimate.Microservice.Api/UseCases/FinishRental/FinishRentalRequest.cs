using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.FinishRental
{
    public record class FinishRentalRequest : IRequest<IWebApiPresenter>
    {
        public FinishRentalRequest(Guid id)
        {
            Id = id;
        }

        [Required]
        public Guid Id { get; private set; }
    }
}
