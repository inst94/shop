using Newtonsoft.Json;
using System;

namespace shop.Core.Dtos.Weather
{
    public class DailyForecastDto
    {
        [JsonProperty("Date")]
        public string Date {get; set;}
        [JsonProperty("EpochDate")]
        public Int64 EpochDate {get; set;}
        public SunDto Sun {get; set;}
        public MoonDto Moon { get; set; }
        public TemperatureDto Temperature { get; set; }
        public RealFeelTemperatureDto RealFeelTemperature { get; set; }
        public RealFeelTemperatureShadeDto RealFeelTemperatureShade { get; set; }
        [JsonProperty("HoursOfSun")]
        public float HoursOfSun { get; set; }
        public DegreeDaySummaryDto DegreeDaySummary { get; set; }
        public AirAndPollenDto AirAndPollen { get; set; }
        public DayDto Day {get; set; }
        public NightDto Night { get; set; }
        [JsonProperty("Sources")]
        public string Sources { get; set; }
        [JsonProperty("MobileLink")]
        public string MobileLink { get; set; }
        [JsonProperty("Link")]
        public string Link { get; set; }
    }
}
