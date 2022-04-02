namespace WeatherApi.Api.BackgroundTasks
{
    public class WeatherDataProvider : IHostedService
    {
        private readonly ILogger<WeatherDataProvider> _logger;
        private readonly IWorker _worker;

        public WeatherDataProvider(ILogger<WeatherDataProvider> logger, IWorker worker)
        {
            _logger = logger;
            _worker = worker;
        }


        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _worker.DoWork(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Stopping job for {nameof(WeatherDataProvider)}.");
            return Task.CompletedTask;
        }
    }
}
