
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

//var client = serviceProvider.GetRequiredService<IExternalWeatherApi>();
//var response = await client.SearchByCityName(
//    new ListonicTask_WebApi.CityWeatherRequest
//    {
//        CityName = "Warsaw",
//        NumberOfDays = 1,
//        CurrentWeatherConditions = "no",
//        Format = "json",
//        Key = "c75e092ab5d74b8d868171412222903"
//    });


//var responseText = JsonSerializer.Serialize(response, new JsonSerializerOptions
//{
//    WriteIndented = true,
//});

//Console.WriteLine(responseText);