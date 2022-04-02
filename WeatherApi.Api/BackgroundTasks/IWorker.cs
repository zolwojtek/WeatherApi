namespace WeatherApi.Api.BackgroundTasks
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}