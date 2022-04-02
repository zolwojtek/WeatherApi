using WeatherApi.Api;
using WeatherApi.Api.BackgroundTasks;
using WeatherApi.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IWeatherData, WeatherData>();
builder.Services.AddHostedService<DataProviderBackgroundService>();
builder.Services.AddSingleton<IWorker, Worker>();


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

