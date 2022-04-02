using OneOf;
using WeatherApi.Cli.Models;

namespace WeatherApi.Cli.Services
{
    public interface IWeatherService
    {
        Task<OneOf<CityWeatherResult, CityWeatherSearchError>> SearchByCityNameAsync(CityWeatherSearchRequest request);
    }
}
