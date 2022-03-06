using Newtonsoft.Json;
using System;

namespace shop.Core.Dtos.OpenWeather
{
    public class WeatherDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Main")]
        public string Main { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("Icon")]
        public string Icon { get; set; }
    }
}
