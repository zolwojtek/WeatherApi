using FluentValidation;
using Polly;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Refit;
using WeatherApi.Api;
using WeatherApi.Api.Data;
using WeatherApi.Api.Jobs;
using WeatherApi.Api.Schedulers;
using WeatherApi.Cli.Models;
using WeatherApi.Cli.Services;
using WeatherApi.Cli.Validators;

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
    cronExpression: "0 0/1 * 1/1 * ? *")); // run every 5 min

builder.Services.AddSingleton<IWeatherService, WeatherService>();
builder.Services.AddSingleton<IValidator<CityWeatherSearchRequest>, CityWeatherSearchRequestValidator>();
builder.Services.AddRefitClient<IExternalWeatherApi>()
    .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
    {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10)
    }))
    .ConfigureHttpClient(httpClient =>
    {
        httpClient.BaseAddress = new Uri(builder.Configuration["ExternalWeatherApi:BaseAddress"]);
    });

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

