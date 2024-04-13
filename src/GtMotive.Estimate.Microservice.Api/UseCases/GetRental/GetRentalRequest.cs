using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetRental
{
    public record class GetRentalRequest : IRequest<IWebApiPresenter>
    {
        public GetRentalRequest(Guid id)
        {
            Id = id;
        }

        [Required]
        public Guid Id { get; private set; }
    }
}
