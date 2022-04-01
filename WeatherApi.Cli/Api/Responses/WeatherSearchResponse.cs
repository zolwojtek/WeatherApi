using System.Text.Json.Serialization;

namespace ListonicTask_WebApi.Api.Responses
{
    public record WeatherSearchResponse
    {
        [JsonPropertyName("data")]
        public DataResponse Data { get; init; }
    }
}