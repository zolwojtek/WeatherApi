
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Text.Json;
using WeatherApi.Cli;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection();
services.ConfigureServices(configuration);

var serviceProvider = services.GetServiceProvider(configuration);

var app = serviceProvider.GetRequiredService<WeatherApplication>();

await app.RunAsync(args);
