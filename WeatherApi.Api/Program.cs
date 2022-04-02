using WeatherApi.Api;
using WeatherApi.Api.Extensions;
using WeatherApi.Cli.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDataServices();
builder.Services.ConfigureSchedulerServices();
builder.Services.ConfigureWeatherServices(builder.Configuration);

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

