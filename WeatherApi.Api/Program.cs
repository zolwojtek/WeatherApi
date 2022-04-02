using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using WeatherApi.Api;
using WeatherApi.Api.BackgroundTasks;
using WeatherApi.Api.Data;
using WeatherApi.Api.Jobs;
using WeatherApi.Api.Schedulers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IWeatherData, WeatherData>();
//builder.Services.AddHostedService<DataProviderBackgroundService>();
//builder.Services.AddSingleton<IWorker, Worker>();

// Add Quartz services
builder.Services.AddHostedService<HostedService>();
builder.Services.AddSingleton<IJobFactory, SingletonJobFactory>();
builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
// Add our job
builder.Services.AddSingleton<DataProviderJob>();
builder.Services.AddSingleton(new JobSchedule(
    jobType: typeof(DataProviderJob),
    cronExpression: "0 0/5 * 1/1 * ? *")); // run every 5 min


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureApi();

app.Run();

