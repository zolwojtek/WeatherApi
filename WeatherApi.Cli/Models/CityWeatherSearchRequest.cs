namespace WeatherApi.Cli.Models
{
    public record CityWeatherSearchRequest
    {
        public CityWeatherSearchRequest(string cityName)
        {
            CityName = cityName;
        }

        public string CityName { get; }
    }
}
