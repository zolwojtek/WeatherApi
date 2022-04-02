using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApi.Cli.Models
{
    public record CityWeatherSearchRequest
    {
        public CityWeatherSearchRequest(string cityName)
        {
            CityName = cityName;
        }

        public string CityName { get; }
    }
}
