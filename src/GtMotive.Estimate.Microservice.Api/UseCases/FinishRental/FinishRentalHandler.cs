using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FinishRental;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.FinishRental
{
    public class FinishRentalHandler : IRequestHandler<FinishRentalRequest, IWebApiPresenter>
    {
        private readonly IFinishRentalUseCase _useCase;
        private readonly IFinishRentalPresenter _presenter;

        public FinishRentalHandler(IFinishRentalUseCase useCase, IFinishRentalPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IWebApiPresenter> Handle(FinishRentalRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
            }

            var input = new FinishRentalInput(request.Id);
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
