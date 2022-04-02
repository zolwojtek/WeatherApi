using WeatherApi.Cli.Domain;

namespace WeatherApi.Cli.Models
{
    public record WeatherResult
    {
        public Celcius AverageCelciusTemperature { get; init; }
    }
}