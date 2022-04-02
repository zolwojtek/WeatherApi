using Quartz;

namespace WeatherApi.Api.Jobs
{
    public class DataProviderJob : IJob
    {
        private readonly ILogger<DataProviderJob> _logger;
        private readonly IServiceProvider _provider;

        public DataProviderJob(ILogger<DataProviderJob> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;

        }
        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Logging very shity informations");

            return Task.CompletedTask;
        }
       
    }
}
