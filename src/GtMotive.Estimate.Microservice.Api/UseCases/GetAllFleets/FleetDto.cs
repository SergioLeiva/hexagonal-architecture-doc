using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllFleets
{
    public class FleetDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FleetDto"/> class.
        /// </summary>
        /// <param name="id">Input id.</param>
        /// <param name="name">Input name.</param>
        public FleetDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }
    }
}
