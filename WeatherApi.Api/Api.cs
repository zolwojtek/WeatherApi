using WeatherApi.Api.Data;

namespace WeatherApi.Api
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/weather/{cityName}", GetCityWeather);
        }

        private static async Task<IResult> GetCityWeather(string cityName, IWeatherData weatherData)
        {
            try
            {
                var result = await weatherData.GetWeatherForCity(cityName);
                if (result == null) return Results.NotFound();
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
