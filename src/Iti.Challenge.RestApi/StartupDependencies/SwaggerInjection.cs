using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Iti.Challenge.RestApi.Dependencies
{
    public static class SwaggerInjection
    {
        public static void AddSwaggerDocService(this IServiceCollection services)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerGeneratorOptions.IgnoreObsoleteActions = true;
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Iti Challenge Rest API",
                    Description = "Rest API to check if a password is valid for Iti Backend Challenge",
                    Contact = new OpenApiContact
                    {
                        Name = "Bruno Romano",
                        Email = "brunopromano@gmail.com",
                    }
                });
            });
        }

        public static void UseSwaggerApiDoc(this IApplicationBuilder app)
        {
            if (app is null) throw new ArgumentException(nameof(app));

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rest API for Iti Backend Challenge");
            });
        }
    }
}