using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using WeatherApi.Api.Data;
using WeatherApi.Api.Jobs;
using WeatherApi.Api.Schedulers;

namespace WeatherApi.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDataServices(this IServiceCollection services)
        {
           services.AddSingleton<IWeatherData, WeatherData>();
        }

        public static void ConfigureSchedulerServices(this IServiceCollection services)
        {
            // Add Quartz services
            services.AddHostedService<HostedService>();
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            // Add scheduled job
            services.AddSingleton<DataProviderJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(DataProviderJob),
                cronExpression: "0 0 6 * * ?")); // run every 1 min
        }
    }
}
