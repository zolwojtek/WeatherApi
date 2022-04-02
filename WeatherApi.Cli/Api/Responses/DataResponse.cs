using System.Text.Json.Serialization;

namespace WeatherApi.Cli.Api.Responses
{
    public record DataResponse
    {
        [JsonPropertyName("weather")]
        public IReadOnlyList<WeatherResponse> Weather { get; init; }
    }
}