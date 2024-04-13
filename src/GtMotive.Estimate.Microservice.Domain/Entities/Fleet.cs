using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represent a fleet.
    /// </summary>
    public class Fleet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Fleet"/> class.
        /// </summary>
        /// <param name="name">The name of the fleet.</param>
        public Fleet(string name)
        {
            Id = Guid.NewGuid();
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
