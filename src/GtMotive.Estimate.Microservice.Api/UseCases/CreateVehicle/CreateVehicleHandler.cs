using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateFleet
{
    public class CreateVehicleHandler : IRequestHandler<CreateVehicleRequest, IWebApiPresenter>
    {
        private readonly ICreateVehicleUseCase _useCase;
        private readonly ICreateVehiclePresenter _presenter;

        public CreateVehicleHandler(ICreateVehicleUseCase useCase, ICreateVehiclePresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IWebApiPresenter> Handle(CreateVehicleRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
            }

            var input = new CreateVehicleInput(request.FleetName, request.LicencePlate, request.Brand, request.ManufacturingYear, request.IsRented);
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
