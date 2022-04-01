
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Text.Json;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection();

services.AddRefitClient<IExternalWeatherApi>()
    .ConfigureHttpClient(httpClient =>
    {
        httpClient.BaseAddress = new Uri(configuration["ExternalWeatherApi:BaseAddress"]);
    });


var serviceProvider = services.BuildServiceProvider();

var client = serviceProvider.GetRequiredService<IExternalWeatherApi>();
var response = await client.SearchByCityName(
    new ListonicTask_WebApi.CityWeatherRequest
    {
        CityName = "Warsaw",
        NumberOfDays = 1,
        CurrentWeatherConditions = "no",
        Format = "json",
        Key = "c75e092ab5d74b8d868171412222903"
    });


var responseText = JsonSerializer.Serialize(response, new JsonSerializerOptions
{
    WriteIndented = true,
});

Console.WriteLine(responseText);