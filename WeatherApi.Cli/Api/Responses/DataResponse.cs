using System.Text.Json.Serialization;

namespace ListonicTask_WebApi.Api.Responses
{
    public record DataResponse
    {
        [JsonPropertyName("weather")]
        public IReadOnlyList<WeatherResponse> Weather { get; init; }
    }
}