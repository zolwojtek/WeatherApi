using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Cli.Output;

namespace WeatherApi.Cli
{
    public class WeatherApplication
    {
        public readonly IConsoleWriter _consoleWriter;

        public WeatherApplication(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public async Task RunAsync(string[] args)
        {
            await Parser.Default
                .ParseArguments<WeatherApplicationOptions>(args)
                .WithParsedAsync(option =>
                {
                    _consoleWriter.WriteLine($"The city was {option.CityName}");
                    return Task.CompletedTask;
                });
        }
    }
}
