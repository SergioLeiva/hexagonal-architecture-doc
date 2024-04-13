namespace GtMotive.Estimate.Microservice.ApplicationCore.Validations.Vehicle
{
    /// <summary>
    /// Interface with validations for the vehicle.
    /// </summary>
    public interface IVehicleValidationService
    {
        /// <summary>
        /// Validation of the manufacturing date 5 years ago.
        /// </summary>
        /// <param name="manufacturingYear">Manufacturing year of the car.</param>
        /// <returns>A boolean indicating whether the vehicle is more than 5 years old.</returns>
        public bool ManufacturingDateValid(int manufacturingYear);
    }
}
