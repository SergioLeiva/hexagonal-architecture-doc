using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateRental
{
    public class CreateRentalHandler : IRequestHandler<CreateRentalRequest, IWebApiPresenter>
    {
        private readonly ICreateRentalUseCase _useCase;
        private readonly ICreateRentalPresenter _presenter;

        public CreateRentalHandler(ICreateRentalUseCase useCase, ICreateRentalPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IWebApiPresenter> Handle(CreateRentalRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
            }

            var input = new CreateRentalInput(request.VehicleLicencePlate, request.ClientId);
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
