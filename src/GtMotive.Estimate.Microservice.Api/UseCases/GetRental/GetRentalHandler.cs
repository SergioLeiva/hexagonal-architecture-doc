using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetRental;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetRental
{
    public class GetRentalHandler : IRequestHandler<GetRentalRequest, IWebApiPresenter>
    {
        private readonly IGetRentalUseCase _useCase;
        private readonly IGetRentalPresenter _presenter;

        public GetRentalHandler(IGetRentalUseCase useCase, IGetRentalPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IWebApiPresenter> Handle(GetRentalRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
            }

            var input = new GetRentalInput(request.Id);
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
