using FluentValidation;
using OneOf;
using WeatherApi.Cli.Api.Requests;
using WeatherApi.Cli.Mapping;
using WeatherApi.Cli.Models;

namespace WeatherApi.Cli.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IExternalWeatherApi _externalWeatherApi;
        private readonly IValidator<CityWeatherSearchRequest> _validator;

        public WeatherService(IExternalWeatherApi externalWeatherApi, IValidator<CityWeatherSearchRequest> validator)
        {
            _externalWeatherApi = externalWeatherApi;
            _validator = validator;
        }

        public async Task<OneOf<CityWeatherResult,CityWeatherSearchError>> SearchByCityNameAsync(CityWeatherSearchRequest request)
        {
            var validationResult = _validator.Validate(request);
            if(validationResult.IsValid == false)
            {
                var errorMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return new CityWeatherSearchError(errorMessages);
            }

            var cityWeatherRequest = new CityWeatherRequest()//TO-DO extract to request factory
            {
                CityName = request.CityName,
                CurrentWeatherConditions = "no",
                Format = "json",
                NumberOfDays = 1,
                Key = "c75e092ab5d74b8d868171412222903"
            };

            var response = await _externalWeatherApi.SearchByCityNameAsync(cityWeatherRequest);
            return response.ToCityWeatherSearchResult();

        }
    }
}
