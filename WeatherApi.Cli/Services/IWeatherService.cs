﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Cli.Models;

namespace WeatherApi.Cli.Services
{
    public interface IWeatherService
    {
        Task<CityWeatherSearchResult> SearchByCityNameAsync(CityWeatherSearchRequest request);
    }
}