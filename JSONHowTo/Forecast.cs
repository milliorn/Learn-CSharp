using System;
using System.Text.Json.Serialization;

namespace JSONHowTo
{
    public class Forecast
    {
        [JsonInclude]
        public DateTime Date;
        [JsonInclude]
        public int TemperatureC;
        [JsonInclude]
        public string Summary;
    }
}
