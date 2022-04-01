using System.Text.Json.Serialization;

namespace ListonicTask_WebApi.Api.Responses
{
    public record class WeatherResponse
    {
        [JsonPropertyName("avgtempC")]
        public string AverageCelciusTemperature { get; init; }
    }
}