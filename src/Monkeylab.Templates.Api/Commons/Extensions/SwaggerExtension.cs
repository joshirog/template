using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Monkeylab.Templates.Api.Commons.Extensions
{
    public static class SwaggerExtension
    {
        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                foreach (var description in ApiVersionDescriptions(services))
                {
                    options.SwaggerDoc(description.GroupName, CreateMetaInfoAPIVersion(description));
                }

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlpath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                
                options.IncludeXmlComments(xmlpath);
                options.CustomSchemaIds(x => x.FullName);
            });
        }

        public static void AddSwaggerApp(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "/swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json", 
                        description.GroupName.ToUpperInvariant());
                }
            });
        }

        private static OpenApiInfo CreateMetaInfoAPIVersion(ApiVersionDescription apiDescription)
        {
            return new OpenApiInfo
            {
                Title = "MyTestService",
                Version = apiDescription.ApiVersion.ToString(),
                Description = " This service is TEST sample service which provides ability to get weather control data ",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Example Contact",
                    Url = new Uri("https://example.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Example License",
                    Url = new Uri("https://example.com/license")
                }
            };
        }
        
        private static IEnumerable<ApiVersionDescription> ApiVersionDescriptions(IServiceCollection services)
        {
            return services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>().ApiVersionDescriptions;
        }
    }
}