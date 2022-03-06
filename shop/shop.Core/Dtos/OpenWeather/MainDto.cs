using Newtonsoft.Json;
using System;

namespace shop.Core.Dtos.OpenWeather
{
    public class MainDto
    {
        [JsonProperty("Temp")]
        public double Temp { get; set; }
        [JsonProperty("Feels_like")]
        public double Feels_like { get; set; }
        [JsonProperty("Temp_min")]
        public double Temp_min { get; set; }
        [JsonProperty("Temp_max")]
        public double Temp_max { get; set; }
        [JsonProperty("Pressure")]
        public int Pressure { get; set; }
        [JsonProperty("Humidity")]
        public int Humidity { get; set; }
    }
}
