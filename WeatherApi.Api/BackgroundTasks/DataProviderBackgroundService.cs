namespace WeatherApi.Api.BackgroundTasks
{
    public class DataProviderBackgroundService : BackgroundService
    {
        private readonly IWorker _worker;

        public DataProviderBackgroundService(IWorker worker)
        {
            _worker = worker;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _worker.DoWork(stoppingToken);
        }
    }
}
