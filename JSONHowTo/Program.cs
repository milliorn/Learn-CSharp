using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
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

            //  The following example creates JSON as a string
            string jsonString = JsonSerializer.Serialize(weather);
            Console.WriteLine("Create JSON as a string\n\n" + jsonString + "\n");

            //  The following example uses synchronous code to create a JSON file
            string fileName = "WeatherForecast.json";
            File.WriteAllText(fileName, jsonString);

            //  The following example uses asynchronous code to create a JSON file
            fileName = "WeatherForecastAsync.json";
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, weather);
            await createStream.DisposeAsync();
            Console.WriteLine("Asynchronous code to create a JSON file\n\n" + File.ReadAllText(fileName) + "\n");

            //  The preceding examples use type inference for the type being serialized. 
            //  An overload of Serialize() takes a generic type parameter
            jsonString = JsonSerializer.Serialize<WeatherForecast>(weather);
            Console.WriteLine("Type Inference\n\n" + jsonString + "\n");

            //  User-defined type is serialized
            var options = new JsonSerializerOptions { WriteIndented = true };
            jsonString = JsonSerializer.Serialize(weather, options);
            Console.WriteLine("User-Defined Type Serialized\n\n" + jsonString + "\n");

            //  Serializing to a UTF-8 byte array is about 5-10% faster than using the string-based methods. 
            //  The difference is because the bytes (as UTF-8) don't need to be converted to strings (UTF-16).
            //  https://stackoverflow.com/questions/10940883/c-converting-byte-array-to-string-and-printing-out-to-console
            byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(weather);
            Console.WriteLine("Serializing to a UTF-8 Byte Array\n\n" + Encoding.UTF8.GetString(jsonUtf8Bytes));

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
            Console.WriteLine("\n");
            Console.WriteLine($"Date: {weatherForecast.Date}");
            Console.WriteLine($"TemperatureCelsius: {weatherForecast.TemperatureCelsius}");
            Console.WriteLine($"Summary: {weatherForecast.Summary}");

            //  To deserialize from a file by using asynchronous code
            using FileStream openStream = File.OpenRead(fileName);
            WeatherForecast forecast = await JsonSerializer.DeserializeAsync<WeatherForecast>(openStream);
            Console.WriteLine($"Date: {weatherForecast.Date}");
            Console.WriteLine($"TemperatureCelsius: {weatherForecast.TemperatureCelsius}");
            Console.WriteLine($"Summary: {weatherForecast.Summary}");
            DeserializeFromUTF8(jsonUtf8Bytes);

            //  To pretty-print the JSON output
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            Console.WriteLine("\nSerialize to formatted JSON\n\n" + jsonString);

            //  Include fields when serializing or deserializing
            string json = @"{""Date"":""2020-09-06T11:31:01.923395"",""TemperatureC"":-1,""Summary"":""Cold""} ";
            Console.WriteLine($"Input JSON: {json}");
            options = new JsonSerializerOptions { IncludeFields = true };
            Forecast newForecast = JsonSerializer.Deserialize<Forecast>(json, options);

            Console.WriteLine($"forecast.Date: {newForecast.Date}");
            Console.WriteLine($"forecast.TemperatureC: {newForecast.TemperatureC}");
            Console.WriteLine($"forecast.Summary: {newForecast.Summary}");

            string roundTrippedJson = JsonSerializer.Serialize<Forecast>(newForecast, options);

            Console.WriteLine($"Output JSON: {roundTrippedJson}");

            var forecast2 = JsonSerializer.Deserialize<Forecast>(json);

            Console.WriteLine($"forecast2.Date: {forecast2.Date}");
            Console.WriteLine($"forecast2.TemperatureC: {forecast2.TemperatureC}");
            Console.WriteLine($"forecast2.Summary: {forecast2.Summary}");

            roundTrippedJson = JsonSerializer.Serialize<Forecast>(newForecast);

            Console.WriteLine($"Output JSON: {roundTrippedJson}");

            //  HttpClient and HttpContent
            using HttpClient client = new()
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
            };

            Console.WriteLine("\nHttpClient and HttpContent\n\nGet the user information\n");

            // Get the user information.
            User user = await client.GetFromJsonAsync<User>("users/1");
            Console.WriteLine($"Id: {user.Id}");
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Username: {user.Username}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine("\nPost a new user\n");
            // Post a new user
            HttpResponseMessage response = await client.PostAsJsonAsync("users", user);
            Console.WriteLine($"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");
        }

        private static void DeserializeFromUTF8(byte[] jsonUtf8Bytes)
        {
            ReadOnlySpan<byte> readOnlySpan = new ReadOnlySpan<byte>(jsonUtf8Bytes);
            WeatherForecast deserializedWeatherForecast = JsonSerializer.Deserialize<WeatherForecast>(readOnlySpan);
        }

        private static void SerializeFromUTF8(byte[] jsonUft8Bytes)
        {
            Utf8JsonReader utf8Reader = new Utf8JsonReader(jsonUft8Bytes);
            WeatherForecast deserializedWeatherForecast = JsonSerializer.Deserialize<WeatherForecast>(ref utf8Reader);
        }
    }
}
