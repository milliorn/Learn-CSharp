using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace JSONHowTo
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }
}