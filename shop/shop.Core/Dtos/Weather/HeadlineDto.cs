using Newtonsoft.Json;
using System;

namespace shop.Core.Dtos.Weather
{
    public class HeadlineDto
    {
        [JsonProperty ("EffectiveDate")]
        public string EffectiveDate { get; set; }
        public Int64 EffectiveEpochDate { get; set; }
        public int Severity { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public string EndDate { get; set; }
        public Int64 EndEpochDate { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }
}
