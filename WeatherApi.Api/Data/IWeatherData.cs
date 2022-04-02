using WeatherApi.Cli.Models;

namespace WeatherApi.Api.Data
{
    public interface IWeatherData
    {
        Task<WeatherResult> GetWeatherForCity(string cityName);
    }
}
