using CommandLine;
using OneOf;
using System.Text.Json;
using WeatherApi.Cli.Models;
using WeatherApi.Cli.Output;
using WeatherApi.Cli.Services;

namespace WeatherApi.Cli.Application
{
    public class WeatherApplication
    {
        public readonly IConsoleWriter _consoleWriter;
        public readonly IWeatherService _weatherService;

        public WeatherApplication(IConsoleWriter consoleWriter, IWeatherService weatherService)
        {
            _consoleWriter = consoleWriter;
            _weatherService = weatherService;
        }

        public async Task RunAsync(string[] args)
        {
            await Parser.Default
                .ParseArguments<WeatherApplicationOptions>(args)
                .WithParsedAsync(async option =>
                {
                    var searchRequest = new CityWeatherSearchRequest(option.CityName);
                    var result = await _weatherService.SearchByCityNameAsync(searchRequest);

                    HandleSearchResult(result);
                });
        }

        private void HandleSearchResult(OneOf<CityWeatherResult, CityWeatherSearchError> result)
        {
            result.Switch(searchResult =>
            {
                var formattedTestResult = JsonSerializer.Serialize(searchResult, new JsonSerializerOptions
                {
                    WriteIndented = true,
                });
                _consoleWriter.WriteLine(formattedTestResult);
            },
            error =>
            {
                var formattedErrors = string.Join(",", error.ErrorMessages);
                _consoleWriter.WriteLine(formattedErrors);
            });
        }
    }
}
