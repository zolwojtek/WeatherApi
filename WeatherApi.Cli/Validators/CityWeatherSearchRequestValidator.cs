using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Cli.Models;

namespace WeatherApi.Cli.Validators
{
    public class CityWeatherSearchRequestValidator : AbstractValidator<CityWeatherSearchRequest>
    {
        //private list
        public CityWeatherSearchRequestValidator()
        {
            RuleFor(request => request.CityName)
                .Matches("^([A-Za-z]*)$")
                .WithMessage("blab");
        }
    }
}
