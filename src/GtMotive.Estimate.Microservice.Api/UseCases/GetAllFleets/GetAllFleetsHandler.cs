using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllFleets;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllFleets
{
    public class GetAllFleetsHandler : IRequestHandler<GetAllFleetsRequest, IWebApiPresenter>
    {
        private readonly IGetAllFleetsUseCase _useCase;
        private readonly IGetAllFleetsPresenter _presenter;

        public GetAllFleetsHandler(IGetAllFleetsUseCase useCase, IGetAllFleetsPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IWebApiPresenter> Handle(GetAllFleetsRequest request, CancellationToken cancellationToken)
        {
            var input = new GetAllFleetsInput();
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
