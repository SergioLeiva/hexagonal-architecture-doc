using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateFleet
{
    public record class CreateFleetRequest : IRequest<IWebApiPresenter>
    {
        public CreateFleetRequest(string name)
        {
            Name = name;
        }

        [Required]
        public string Name { get; private set; }
    }
}
