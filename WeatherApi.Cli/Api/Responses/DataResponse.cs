using System.Text.Json.Serialization;

namespace ListonicTask_WebApi.Api.Responses
{
    public record DataResponse
    {
        [JsonPropertyName("weather")]
        public List<WeatherResponse> Weather { get; init; }
    }
}