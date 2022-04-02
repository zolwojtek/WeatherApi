using ListonicTask_WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Cli.Models;

namespace WeatherApi.Cli.Services
{
    public class WeatherService : IWeatherService
    {
        public async Task<CityWeatherSearchResult> SearchByCityNameAsync(CityWeatherSearchRequest request)
        {
            return Task.CompletedTask;
        }
    }
}
