using Newtonsoft.Json;
using System;

namespace shop.Core.Dtos.OpenWeather
{
    public class SysDto
    {
        [JsonProperty("Type")]
        public int Type { get; set; }
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Message")]
        public double Message { get; set; }
        [JsonProperty("Country")]
        public string Country { get; set; }
        [JsonProperty("Sunrise")]
        public int Sunrise { get; set; }
        [JsonProperty("Sunset")]
        public int Sunset { get; set; }
    }
}
