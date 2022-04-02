using OneOf;
using Quartz;
using System.Text.Json;
using WeatherApi.Api.Data;
using WeatherApi.Cli.Models;
using WeatherApi.Cli.Services;

namespace WeatherApi.Api.Jobs
{
    public class DataProviderJob : IJob
    {
        private readonly ILogger<DataProviderJob> _logger;
        private readonly IServiceProvider _provider;
        private readonly IWeatherService _weatherService;
        private readonly IWeatherData _weatherData;

        public DataProviderJob(ILogger<DataProviderJob> logger, IServiceProvider provider, IWeatherService weatherService, IWeatherData weatherData)
        {
            _logger = logger;
            _provider = provider;
            _weatherService = weatherService;
            _weatherData = weatherData;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Logging very importnant informations");

            foreach(var key in _weatherData.CachedData.Keys )
            {
                var searchRequest = new CityWeatherSearchRequest(key);
                var result = await _weatherService.SearchByCityNameAsync(searchRequest);

                HandleSearchResult(key, result);
            }
        }

        private void HandleSearchResult(string key, OneOf<CityWeatherResult, CityWeatherSearchError> result)
        {
            result.Switch(searchResult =>
            {
                var formattedTestResult = JsonSerializer.Serialize(searchResult, new JsonSerializerOptions
                {
                    WriteIndented = true,
                });
                _logger.LogInformation(formattedTestResult);

                if (_weatherData.CachedData.TryGetValue(key, out WeatherResult expectedValue))
                {
                    _weatherData.CachedData.TryUpdate(key, new WeatherResult
                    {
                        AverageCelciusTemperature = searchResult.Weather.AverageCelciusTemperature
                    },
                    expectedValue);
                    _logger.LogInformation("Successfully updated weather for {}.", key);
                    return;
                }
                _logger.LogError("Could not update the weather for {}.", key);
            },
            error =>
            {
                var formattedErrors = string.Join(",", error.ErrorMessages);
                _logger.LogInformation(formattedErrors);
            });
        }

    }
}
