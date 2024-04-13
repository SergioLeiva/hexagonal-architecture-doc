using GtMotive.Estimate.Microservice.Api.UseCases.CreateFleet;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateRental;
using GtMotive.Estimate.Microservice.Api.UseCases.FinishRental;
using GtMotive.Estimate.Microservice.Api.UseCases.GetAllFleets;
using GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehiclesAvailables;
using GtMotive.Estimate.Microservice.Api.UseCases.GetRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateFleet;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FinishRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllFleets;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehiclesAvailables;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetRental;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<CreateFleetPresenter>();
            services.AddScoped<ICreateFleetOutputPort>(x => x.GetRequiredService<CreateFleetPresenter>());
            services.AddScoped<ICreateFleetPresenter>(x => x.GetRequiredService<CreateFleetPresenter>());

            services.AddScoped<GetAllFleetsPresenter>();
            services.AddScoped<IGetAllFleetsOutputPort>(x => x.GetRequiredService<GetAllFleetsPresenter>());
            services.AddScoped<IGetAllFleetsPresenter>(x => x.GetRequiredService<GetAllFleetsPresenter>());

            services.AddScoped<CreateVehiclePresenter>();
            services.AddScoped<ICreateVehicleOutputPort>(x => x.GetRequiredService<CreateVehiclePresenter>());
            services.AddScoped<ICreateVehiclePresenter>(x => x.GetRequiredService<CreateVehiclePresenter>());

            services.AddScoped<GetAllVehiclesAvailablesPresenter>();
            services.AddScoped<IGetAllVehiclesAvailablesOutputPort>(x => x.GetRequiredService<GetAllVehiclesAvailablesPresenter>());
            services.AddScoped<IGetAllVehiclesAvailablesPresenter>(x => x.GetRequiredService<GetAllVehiclesAvailablesPresenter>());

            services.AddScoped<CreateRentalPresenter>();
            services.AddScoped<ICreateRentalOutputPort>(x => x.GetRequiredService<CreateRentalPresenter>());
            services.AddScoped<ICreateRentalPresenter>(x => x.GetRequiredService<CreateRentalPresenter>());

            services.AddScoped<FinishRentalPresenter>();
            services.AddScoped<IFinishRentalOutputPort>(x => x.GetRequiredService<FinishRentalPresenter>());
            services.AddScoped<IFinishRentalPresenter>(x => x.GetRequiredService<FinishRentalPresenter>());

            services.AddScoped<GetRentalPresenter>();
            services.AddScoped<IGetRentalOutputPort>(x => x.GetRequiredService<GetRentalPresenter>());
            services.AddScoped<IGetRentalPresenter>(x => x.GetRequiredService<GetRentalPresenter>());

            return services;
        }
    }
}
