using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using AzureFunctions.Extensions.Swashbuckle;
using Microsoft.OpenApi;
using AzureFunctions.Extensions.Swashbuckle.Settings;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services => {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddSwashBuckle(opts =>
        {
            opts.AddNewtonsoftSupport = true;
            opts.RoutePrefix = "api";
            opts.SpecVersion = OpenApiSpecVersion.OpenApi3_0;
            opts.AddCodeParameter = true;
            opts.PrependOperationWithRoutePrefix = true;
            opts.Documents = new[]
            {
                new SwaggerDocument
                {
                    Name = "v1",
                    Title = "Mitigation calculator",
                    Version = "v2"
                }
            };
            opts.Title = "Mitigation calculator";
        });
    })
    .Build();

host.Run();
