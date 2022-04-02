using System.Collections.Concurrent;
using WeatherApi.Cli.Models;

namespace WeatherApi.Api.Data
{
    public interface IWeatherData
    {
        ConcurrentDictionary<string, WeatherResult> CachedData { get; }
        Task<WeatherResult> GetWeatherForCity(string cityName);
    }
}
