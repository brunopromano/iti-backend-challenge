using Xunit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Iti.Challenge.Tests.Integration
{
    public class PasswordCheckTests : ClientAndServerBaseTest
    {
        [Fact]
        public async Task HeaderMustReturnApplicationJsonCharsetUtf8()
        {
            var body = new { value = "Bg@4iyo!76"};
            var reqData = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var res = await _client.PostAsync("api/password/check", reqData);

            res.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", res.Content.Headers.ContentType.ToString());
            DisposeClientAndServer();
        }

        [Fact]
        public async Task ResponseMustBeOkForCorrectRequestBody()
        {
            var body = new { value = "Bg@4iyo!76"};
            var reqData = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var res = await _client.PostAsync("api/password/check", reqData);
            
            Assert.Equal(HttpStatusCode.OK, res.StatusCode);
            DisposeClientAndServer();
        }

        [Fact]
        public async Task ResponseMustBeBadRequesForBodyWithoutValueKey()
        {
            var body = new { passwordvalue = "Bg@4iyo!76" };
            var reqData = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var res = await _client.PostAsync("api/password/check", reqData);

            Assert.Equal(HttpStatusCode.BadRequest, res.StatusCode);
            DisposeClientAndServer();
        }

        [Fact]
        public async Task ResponseMustBeTrueForValidPassword()
        {
            var body = new { value = "Bg@4iyo!76" };
            var reqData = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            
            var res = await _client.PostAsync("api/password/check", reqData);
            var resJson = JsonConvert.DeserializeObject<PasswordCheckResponse>(await res.Content.ReadAsStringAsync());
            
            Assert.Equal(HttpStatusCode.OK, res.StatusCode);
            Assert.Equal(true, resJson.Valid);
            DisposeClientAndServer();
        }

        [Fact]
        public async Task ResponseMustBeFalseForInvalidPassword()
        {
            var body = new { value = "1h5nb0sbchka"};
            var reqData = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            
            var res = await _client.PostAsync("api/password/check", reqData);
            var resJson = JsonConvert.DeserializeObject<PasswordCheckResponse>(await res.Content.ReadAsStringAsync());

            Assert.Equal(HttpStatusCode.OK, res.StatusCode);
            Assert.Equal(false, resJson.Valid);
            DisposeClientAndServer();
        }
    }
}