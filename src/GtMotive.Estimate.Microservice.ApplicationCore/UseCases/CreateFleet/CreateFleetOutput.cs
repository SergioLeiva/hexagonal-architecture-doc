using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateFleet
{
    /// <summary>
    /// Create Fleet output.
    /// </summary>
    public class CreateFleetOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFleetOutput"/> class.
        /// </summary>
        /// <param name="id">Input value id.</param>
        /// <param name="name">Input value name.</param>
        public CreateFleetOutput(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Gets the unique idenfier of the fleet.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the name of the fleet.
        /// </summary>
        public string Name { get; private set; }
    }
}
