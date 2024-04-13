using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateFleet
{
    public class CreateFleetResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFleetResponse"/> class.
        /// </summary>
        /// <param name="id">Input id.</param>
        /// <param name="name">Input name.</param>
        public CreateFleetResponse(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        [Required]
        public Guid Id { get; private set; }

        [Required]
        public string Name { get; private set; }
    }
}
