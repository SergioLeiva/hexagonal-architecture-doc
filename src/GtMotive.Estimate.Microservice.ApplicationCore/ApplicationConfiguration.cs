using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateFleet;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FinishRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllFleets;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehiclesAvailables;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetRental;
using GtMotive.Estimate.Microservice.ApplicationCore.Validations;
using GtMotive.Estimate.Microservice.ApplicationCore.Validations.Vehicle;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.ApplicationCore
{
    /// <summary>
    /// Adds Use Cases classes.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ApplicationConfiguration
    {
        /// <summary>
        /// Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            // Add scope to validations
            services.AddScoped<IRentalValidationService, RentalValidationService>();
            services.AddScoped<IVehicleValidationService, VehicleValidationService>();

            services.AddScoped<ICreateFleetUseCase, CreateFleetUseCase>();
            services.AddScoped<IGetAllFleetsUseCase, GetAllFleetsUseCase>();

            services.AddScoped<ICreateVehicleUseCase, CreateVehicleUseCase>();
            services.AddScoped<IGetAllVehiclesAvailablesUseCase, GetAllVehiclesAvailablesUseCase>();

            services.AddScoped<ICreateRentalUseCase, CreateRentalUseCase>();
            services.AddScoped<IFinishRentalUseCase, FinishRentalUseCase>();
            services.AddScoped<IGetRentalUseCase, GetRentalUseCase>();

            return services;
        }
    }
}
