using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Iti.Challenge.Tests.Integration
{
    public class SwaggerUserInterfaceTest : ClientAndServerBaseTest
    {
        [Fact]
        public async Task SwaggerUIMustReturnOk()
        {
            var res = await _client.GetAsync("/swagger/index.html");

            Assert.Equal(HttpStatusCode.OK, res.StatusCode);
            DisposeClientAndServer();
        }
    }
}