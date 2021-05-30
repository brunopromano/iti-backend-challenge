using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Iti.Challenge.Tests.Integration
{
    public class HealthChecksTest : ClientAndServerBaseTest
    {
        [Fact]
        public async Task HealthChecksMustReturnOk()
        {
            var res = await _client.GetAsync("/health");

            Assert.Equal(HttpStatusCode.OK, res.StatusCode);
            DisposeClientAndServer();
        }

        [Fact]
        public async Task HealthChecksUIMustReturnOk()
        {
            var res = await _client.GetAsync("/healthchecks-ui");

            Assert.Equal(HttpStatusCode.OK, res.StatusCode);
            DisposeClientAndServer();
        }
    }
}