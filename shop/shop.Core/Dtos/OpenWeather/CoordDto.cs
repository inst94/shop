using Newtonsoft.Json;
using System;

namespace shop.Core.Dtos.OpenWeather
{
    public class CoordDto
    {
        [JsonProperty("Lon")]
        public double Lon { get; set; }
        [JsonProperty("Lat")]
        public double Lat { get; set; }
    }
}
