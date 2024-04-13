using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateFleet;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure
{
    public class AddFleetTest : FunctionalTestBase
    {
        public AddFleetTest(CompositionRootTestFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task AddFleetSuccess()
        {
            var fleetName = "ELECTRIC";

            await Fixture.UsingHandlerForRequestResponse<CreateFleetRequest, IWebApiPresenter>(async handler =>
            {
                var request = new CreateFleetRequest(fleetName);

                var response = await handler.Handle(request, CancellationToken.None);

                Assert.NotNull(response);
            });
        }
    }
}
