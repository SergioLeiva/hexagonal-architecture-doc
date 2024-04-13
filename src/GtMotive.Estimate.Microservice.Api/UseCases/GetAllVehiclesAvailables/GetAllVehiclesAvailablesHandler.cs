using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehiclesAvailables;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehiclesAvailables
{
    public class GetAllVehiclesAvailablesHandler : IRequestHandler<GetAllVehiclesAvailablesRequest, IWebApiPresenter>
    {
        private readonly IGetAllVehiclesAvailablesUseCase _useCase;
        private readonly IGetAllVehiclesAvailablesPresenter _presenter;

        public GetAllVehiclesAvailablesHandler(IGetAllVehiclesAvailablesUseCase useCase, IGetAllVehiclesAvailablesPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IWebApiPresenter> Handle(GetAllVehiclesAvailablesRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
            }

            var input = new GetAllVehiclesAvailablesInput(request.FleetName);
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
