using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Repositories
{
    /// <summary>
    /// Interface interface responsible for managing fleet data.
    /// </summary>
    public interface IFleetRepository
    {
        /// <summary>
        /// Add new fleet to the repository.
        /// </summary>
        /// <param name="fleet">The fleet to be added.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddFleet(Fleet fleet);

        /// <summary>
        /// Return fleet twith specific name.
        /// </summary>
        /// <param name="name">The name of the fleet.</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task<Fleet> GetFleetByName(string name);

        /// <summary>
        /// Return all fleets.
        /// </summary>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task<IEnumerable<Fleet>> GetAllFleets();
    }
}
