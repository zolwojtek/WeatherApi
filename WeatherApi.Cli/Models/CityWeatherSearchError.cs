namespace WeatherApi.Cli.Models
{
    public record CityWeatherSearchError
    {
        public IReadOnlyList<string> ErrorMessages { get; }

        public CityWeatherSearchError(IReadOnlyList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}
