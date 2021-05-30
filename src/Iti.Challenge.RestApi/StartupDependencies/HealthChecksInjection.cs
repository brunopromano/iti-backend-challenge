using System;
using System.Net.Http;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace Iti.Challenge.RestApi.Dependencies
{
    public static class HealthCheksInjection
    {
        public static void AddHealthChecksService(this IServiceCollection services)
        {
            services.AddHealthChecks();

            services.AddHealthChecksUI(setup =>
            {
                setup.UseApiEndpointHttpMessageHandler(sp =>
                {
                    return new HttpClientHandler
                    {
                        ClientCertificateOptions = ClientCertificateOption.Manual,
                        ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => { return true; }
                    };
                    
                });
                
                setup.AddHealthCheckEndpoint("/api/password", "https://localhost:5001/health");
            }).AddInMemoryStorage();
        }

        public static void AddHealthChecksApi(this IApplicationBuilder app)
        {
            if (app is null) throw new ArgumentException(nameof(app));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecksUI();

                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });
        }
    }
}