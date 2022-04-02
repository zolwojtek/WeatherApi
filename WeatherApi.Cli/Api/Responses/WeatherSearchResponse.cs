using System.Text.Json.Serialization;

namespace WeatherApi.Cli.Api.Responses
{
    public record WeatherSearchResponse
    {
        [JsonPropertyName("data")]
        public DataResponse Data { get; init; }
    }
}