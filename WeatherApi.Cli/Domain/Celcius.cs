using ValueOf;

namespace WeatherApi.Cli.Domain
{
    public class Celcius: ValueOf<double, Celcius>
    {
        private readonly double _min = -273.15;

        protected override void Validate()
        {
            if(Value < _min)
            {
                throw new TemperatureBelowAbsoluteZeroException(Value);
            }
        }
    }

    public class TemperatureBelowAbsoluteZeroException : Exception
    {
        public TemperatureBelowAbsoluteZeroException(double degrees)
            : base($"Temperature cannot be below absolute zero. Curren value: {degrees}.")
        {

        }
    }
}
