using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Repositories
{
    /// <summary>
    /// Interface interface responsible for managing vehicle data.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Return vehicle twith specific licence plate.
        /// </summary>
        /// <param name="licencePlate">The licence plate of the vehicle.</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task<Vehicle> GetVehicleByLicencePlate(string licencePlate);

        /// <summary>
        /// Return all vehicles .
        /// </summary>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task<IEnumerable<Vehicle>> GetAllVehicles();

        /// <summary>
        /// Return all vehicles with in a specified fleet.
        /// </summary>
        /// <param name="fleetName">The name of the fleet.</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task<IEnumerable<Vehicle>> GetAllVehiclesByFleet(string fleetName);

        /// <summary>
        /// Add new vehicle to the repository.
        /// </summary>
        /// <param name="vehicle"> The vehicle to be added.</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddVehicle(Vehicle vehicle);

        /// <summary>
        /// Modify the rental status of a vehicle.
        /// </summary>
        /// <param name="licencePlate">The licence plate of the vehicle.</param>
        /// <param name="isRental">The value indicating whether the vehicle is rented.</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task ModifyVehicleRental(string licencePlate, bool isRental);
    }
}
