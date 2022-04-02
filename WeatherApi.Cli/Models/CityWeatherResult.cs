using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApi.Cli.Models
{
    public record CityWeatherResult
    {
        public WeatherResult Weather { get; init; }
    }
}
