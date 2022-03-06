using Newtonsoft.Json;
using System;

namespace shop.Core.Dtos.OpenWeather
{
    public class CloudsDto
    {
        [JsonProperty("All")]
        public int All { get; set; }
    }
}
