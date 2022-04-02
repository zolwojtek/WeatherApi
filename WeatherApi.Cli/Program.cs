
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherApi.Cli.Application;
using WeatherApi.Cli.Extensions;
using WeatherApi.Cli.Output;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection();
services.AddSingleton<WeatherApplication>();
services.AddSingleton<IConsoleWriter, ConsoleWriter>();

services.ConfigureWeatherServices(configuration);

var serviceProvider = services.GetServiceProvider(configuration);

var app = serviceProvider.GetRequiredService<WeatherApplication>();

await app.RunAsync(args);
