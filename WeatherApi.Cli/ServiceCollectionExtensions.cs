using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Cli.Output;

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
            services.AddRefitClient<IExternalWeatherApi>()
                .ConfigureHttpClient(httpClient =>
                {
                    httpClient.BaseAddress = new Uri(configuration["ExternalWeatherApi:BaseAddress"]);
                });
        }
    }
}
