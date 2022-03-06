using Newtonsoft.Json;
using System;

namespace shop.Core.Dtos.OpenWeather
{
    public class WindDto
    {
        [JsonProperty("Speed")]
        public double Speed { get; set; }
        [JsonProperty("Deg")]
        public int Deg { get; set; }
    }
}
