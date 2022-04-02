using ListonicTask_WebApi;
using ListonicTask_WebApi.Api.Responses;
using Refit;

public interface IExternalWeatherApi
{
    [Get("/premium/v1/weather.ashx?q={request.CityName}&num_of_days={request.NumberOfDays}&cc={request.CurrentWeatherConditions}&format={request.Format}&key={request.Key}")]
    Task<WeatherSearchResponse> SearchByCityNameAsync(CityWeatherRequest request);
}
//What if there are several cities in the world with the same name?