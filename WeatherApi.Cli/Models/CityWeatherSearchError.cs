using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApi.Cli.Models
{
    public record CityWeatherSearchError
    {
        public IReadOnlyList<string> ErrorMessages { get; }

        public CityWeatherSearchError(IReadOnlyList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}
