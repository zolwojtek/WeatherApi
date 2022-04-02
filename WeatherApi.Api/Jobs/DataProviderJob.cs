using OneOf;
using Quartz;
using System.Text.Json;
using WeatherApi.Cli.Models;
using WeatherApi.Cli.Services;

namespace WeatherApi.Api.Jobs
{
    public class DataProviderJob : IJob
    {
        private readonly ILogger<DataProviderJob> _logger;
        private readonly IServiceProvider _provider;
        private readonly IWeatherService _weatherService;

        public DataProviderJob(ILogger<DataProviderJob> logger, IServiceProvider provider, IWeatherService weatherService)
        {
            _logger = logger;
            _provider = provider;
            _weatherService = weatherService;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Logging very importnant informations");

            var searchRequest = new CityWeatherSearchRequest("Warsaw");
            var result = await _weatherService.SearchByCityNameAsync(searchRequest);

            HandleSearchResult(result);
        }

        private void HandleSearchResult(OneOf<CityWeatherResult, CityWeatherSearchError> result)
        {
            result.Switch(searchResult =>
            {
                var formattedTestResult = JsonSerializer.Serialize(searchResult, new JsonSerializerOptions
                {
                    WriteIndented = true,
                });
                _logger.LogInformation(formattedTestResult);
            },
            error =>
            {
                var formattedErrors = string.Join(",", error.ErrorMessages);
                _logger.LogInformation(formattedErrors);
            });
        }

    }
}
