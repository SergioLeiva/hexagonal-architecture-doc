using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Validations.Vehicle
{
    /// <summary>
    /// Validations for the vehicle.
    /// </summary>
    public class VehicleValidationService : IVehicleValidationService
    {
        /// <inheritdoc/>
        public bool ManufacturingDateValid(int manufacturingYear)
        {
            var fiveYearsAgo = DateTime.Now.AddYears(-5);
            return manufacturingYear > fiveYearsAgo.Year;
        }
    }
}
