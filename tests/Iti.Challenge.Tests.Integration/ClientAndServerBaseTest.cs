using System;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Iti.Challenge.RestApi;

namespace Iti.Challenge.Tests.Integration
{
    public class ClientAndServerBaseTest
    {
        protected readonly TestServer _server;
        protected readonly HttpClient _client;

        public ClientAndServerBaseTest()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        public void DisposeClientAndServer()
        {
            _server.Dispose();
            _client.Dispose();
        }
    }
}
