using System.Text.Json.Serialization;

namespace WeatherApi.Cli.Api.Responses
{
    public record class WeatherResponse
    {
        [JsonPropertyName("avgtempC")]
        public string AverageCelciusTemperature { get; init; }
    }
}