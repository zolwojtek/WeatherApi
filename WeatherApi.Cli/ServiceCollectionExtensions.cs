using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Cli.Output;
using WeatherApi.Cli.Services;
using FluentValidation;
using Polly;

namespace WeatherApi.Cli
{
    public static class ServiceCollectionExtensions
    {
        public static ServiceProvider GetServiceProvider(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        public static void ConfigureServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton<WeatherApplication>();
            services.AddSingleton<IConsoleWriter, ConsoleWriter>();
            services.AddSingleton<IWeatherService, WeatherService>();
            services.AddValidatorsFromAssemblyContaining<Program>();
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
