using CommandLine;

namespace WeatherApi.Cli.Application
{
    public class WeatherApplicationOptions
    {
        [Option('n', "cityname", Required = true, HelpText = "City name for which the weather is provided.")]
        public string CityName { get; init; }
    }
}
