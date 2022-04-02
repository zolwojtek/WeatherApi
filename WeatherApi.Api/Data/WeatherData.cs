using System.Collections.Concurrent;
using WeatherApi.Cli.Domain;
using WeatherApi.Cli.Models;

namespace WeatherApi.Api.Data
{
    public class WeatherData : IWeatherData
    {
        public ConcurrentDictionary<string, WeatherResult> CachedData { get; }

        public WeatherData()
        {
            CachedData = new ConcurrentDictionary<string, WeatherResult>();

            CachedData.TryAdd("Warszawa", new WeatherResult() { AverageCelciusTemperature = Celcius.From(0) });
            CachedData.TryAdd("Lodz", new WeatherResult() { AverageCelciusTemperature = Celcius.From(0) });
            CachedData.TryAdd("Wroclaw", new WeatherResult() { AverageCelciusTemperature = Celcius.From(0) });
            CachedData.TryAdd("Poznan", new WeatherResult() { AverageCelciusTemperature = Celcius.From(0) });
        }

        public async Task<WeatherResult> GetWeatherForCity(string cityName)
        {
            CachedData.TryGetValue(cityName, out WeatherResult weather);
            return weather;
        }
    }
}
