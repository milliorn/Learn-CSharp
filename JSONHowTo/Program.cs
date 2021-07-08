using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JSONHowTo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("How to serialize and deserialize (marshal and unmarshal) JSON in .NET\n");
            WeatherForecast weather = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot",
                SummaryField = "Hot",
                DatesAvailable = new List<DateTimeOffset>()
                    { DateTime.Parse("2019-08-01"), DateTime.Parse("2019-08-02") },
                TemperatureRanges = new Dictionary<string, HighLowTemps>
                {
                    ["Cold"] = new HighLowTemps { High = 20, Low = -10 },
                    ["Hot"] = new HighLowTemps { High = 60, Low = 20 }
                },
                SummaryWords = new[] { "Cool", "Windy", "Humid" }
            };

            // The following example creates JSON as a string:
            string jsonString = JsonSerializer.Serialize(weather);
            Console.WriteLine(jsonString + "\n");

            //The following example uses synchronous code to create a JSON file
            string fileName = "WeatherForecast.json";
            File.WriteAllText(fileName, jsonString);

            // The following example uses asynchronous code to create a JSON file:
            fileName = "WeatherForecastAsync.json";
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, weather);
            await createStream.DisposeAsync();
            Console.WriteLine(File.ReadAllText(fileName) + "\n");

            //  The preceding examples use type inference for the type being serialized. 
            //  An overload of Serialize() takes a generic type parameter
            jsonString = JsonSerializer.Serialize<WeatherForecast>(weather);
            Console.WriteLine(jsonString + "\n");

            //  User-defined type is serialized
            var options = new JsonSerializerOptions { WriteIndented = true };
            jsonString = JsonSerializer.Serialize(weather, options);
            Console.WriteLine(jsonString + "\n");

            //  Serializing to a UTF-8 byte array is about 5-10% faster than using the string-based methods. 
            //  The difference is because the bytes (as UTF-8) don't need to be converted to strings (UTF-16).
            //  https://stackoverflow.com/questions/10940883/c-converting-byte-array-to-string-and-printing-out-to-console
            byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(weather);
            Console.WriteLine(Encoding.UTF8.GetString(jsonUtf8Bytes));

            jsonString =
@"{
  ""Date"": ""2019-08-01T00:00:00-07:00"",
  ""TemperatureCelsius"": 25,
  ""Summary"": ""Hot"",
  ""DatesAvailable"": [
    ""2019-08-01T00:00:00-07:00"",
    ""2019-08-02T00:00:00-07:00""
  ],
  ""TemperatureRanges"": {
                ""Cold"": {
                    ""High"": 20,
      ""Low"": -10
                },
    ""Hot"": {
                    ""High"": 60,
      ""Low"": 20
    }
            },
  ""SummaryWords"": [
    ""Cool"",
    ""Windy"",
    ""Humid""
  ]
}
";
            //  Deserialize a JSON string:
            WeatherForecast weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString);
            Console.WriteLine($"Date: {weatherForecast.Date}");
            Console.WriteLine($"TemperatureCelsius: {weatherForecast.TemperatureCelsius}");
            Console.WriteLine($"Summary: {weatherForecast.Summary}");
        }
    }
}
