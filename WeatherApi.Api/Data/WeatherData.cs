using WeatherApi.Cli.Domain;
using WeatherApi.Cli.Models;

namespace WeatherApi.Api.Data
{
    public class WeatherData : IWeatherData
    {
        private IReadOnlyDictionary<string, WeatherResult> _fakeCityWeather;

        public WeatherData()
        {
            _fakeCityWeather = new Dictionary<string, WeatherResult>()
            {
                { "Warsaw", new WeatherResult(){AverageCelciusTemperature = Celcius.From(4)} },
                { "Gdansk", new WeatherResult(){AverageCelciusTemperature = Celcius.From(2)} },
                { "Poznan", new WeatherResult(){AverageCelciusTemperature = Celcius.From(3)} },
                { "Crakow", new WeatherResult(){AverageCelciusTemperature = Celcius.From(3)} },
            };
        }

        public async Task<WeatherResult> GetWeatherForCity(string cityName)
        {
            _fakeCityWeather.TryGetValue(cityName, out WeatherResult weather);
            return weather;
        }
    }
}
