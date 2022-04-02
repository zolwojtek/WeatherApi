namespace WeatherApi.Cli.Models
{
    public record CityWeatherResult
    {
        public WeatherResult Weather { get; init; }
    }
}
