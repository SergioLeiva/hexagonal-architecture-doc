using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateFleet;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateFleet
{
    public class CreateFleetHandler : IRequestHandler<CreateFleetRequest, IWebApiPresenter>
    {
        private readonly ICreateFleetUseCase _useCase;
        private readonly ICreateFleetPresenter _presenter;

        public CreateFleetHandler(ICreateFleetUseCase useCase, ICreateFleetPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IWebApiPresenter> Handle(CreateFleetRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
            }

            var input = new CreateFleetInput(request.Name);
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
