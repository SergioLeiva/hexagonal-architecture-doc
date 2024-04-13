using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    [Collection(TestCollections.TestServer)]
    public class FleetsTests : InfrastructureTestBase
    {
        public FleetsTests(GenericInfrastructureTestServerFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task PostFleetsShouldReturnSuccessStatusCode()
        {
            var requestContent = new StringContent(/*lang=json,strict*/ "{\"Name\":\"Electric\"}", Encoding.UTF8, "application/json");

            var url = "api/Fleets/add";
            var uri = new Uri(url, UriKind.Relative);
            var response = await Fixture.Server.CreateClient().PostAsync(uri, requestContent);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            requestContent.Dispose();
        }
    }
}
