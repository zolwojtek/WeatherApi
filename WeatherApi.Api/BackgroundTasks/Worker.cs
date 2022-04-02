namespace WeatherApi.Api.BackgroundTasks
{
    public class Worker : IWorker
    {
        private readonly ILogger<Worker> _logger;
        private int number = 0;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public async Task DoWork(CancellationToken cancellationToken)
        {
            while(cancellationToken.IsCancellationRequested == false)
            {
                Interlocked.Increment(ref number);
                _logger.LogInformation($"Starting job for {nameof(WeatherDataProvider)}. Number: {number}.");
                await Task.Delay(1000 * 5);
            }
        }
    }
}
