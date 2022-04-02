using WeatherApi.Cli.Api.Responses;
using WeatherApi.Cli.Domain;
using WeatherApi.Cli.Models;

namespace WeatherApi.Cli.Mapping
{
    public static class ApiToDomainMapping
    {
        public static CityWeatherResult ToCityWeatherSearchResult(this WeatherSearchResponse response)
        {
            return new()
            {
                Weather = new WeatherResult()
                {
                    AverageCelciusTemperature = Celcius.From(double.Parse(response.Data.Weather.First().AverageCelciusTemperature))
                }
            };
        }
    }
}
