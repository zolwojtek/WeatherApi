using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Refit;
using WeatherApi.Cli.Models;
using WeatherApi.Cli.Services;
using WeatherApi.Cli.Validators;

namespace WeatherApi.Cli.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static ServiceProvider GetServiceProvider(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        public static void ConfigureWeatherServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton<IWeatherService, WeatherService>();
            services.AddSingleton<IValidator<CityWeatherSearchRequest>, CityWeatherSearchRequestValidator>();
            services.AddRefitClient<IExternalWeatherApi>()
                .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10)
                }))
                .ConfigureHttpClient(httpClient =>
                {
                    httpClient.BaseAddress = new Uri(configuration["ExternalWeatherApi:BaseAddress"]);
                });


        }
    }
}
