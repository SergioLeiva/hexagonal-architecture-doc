using System;
using GtMotive.Estimate.Microservice.ApplicationCore.Validations.Vehicle;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests
{
    public class VehicleTests
    {
        [Fact]
        public void ForValidYear()
        {
            var vehicleValidationServiceMock = new Mock<IVehicleValidationService>();
            var manufacturingYear = DateTime.Now.Year; // Current year

            vehicleValidationServiceMock
                .Setup(v => v.ManufacturingDateValid(manufacturingYear))
                .Returns(true);

            var actual = vehicleValidationServiceMock.Object.ManufacturingDateValid(manufacturingYear);

            Assert.True(actual);
        }

        [Fact]
        public void YearBeforeFiveYears()
        {
            var vehicleValidationServiceMock = new Mock<IVehicleValidationService>();
            var fiveYearsAgo = DateTime.Now.AddYears(-5);
            var manufacturingYear = fiveYearsAgo.Year;

            vehicleValidationServiceMock
                .Setup(v => v.ManufacturingDateValid(manufacturingYear))
                .Returns(false);

            var actual = vehicleValidationServiceMock.Object.ManufacturingDateValid(manufacturingYear);

            Assert.False(actual);
        }
    }
}
