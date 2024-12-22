using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Intact.DynamicRendering.Services.AtVantage;
using Microsoft.Extensions.Configuration;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureAppConfiguration(builder =>
    {
        builder.AddEnvironmentVariables();
        builder.SetBasePath(Environment.CurrentDirectory);
    })
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.AddHttpClient();
        services.AddTransient<IAtVantageService, AtVantageService>();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

host.Run();
