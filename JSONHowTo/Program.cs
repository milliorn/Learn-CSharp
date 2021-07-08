using System.IO;
using System;
using System.Text.Json;

namespace JSONHowTo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How to serialize and deserialize (marshal and unmarshal) JSON in .NET");
            WeatherForecast weather = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };

            // The following example creates JSON as a string:
            string jsonString = JsonSerializer.Serialize(weather);
            Console.WriteLine(jsonString);

            //The following example uses synchronous code to create a JSON file
            string fileName = "WeatherForecast.json";
            File.WriteAllText(fileName, jsonString);
        }
    }
}
