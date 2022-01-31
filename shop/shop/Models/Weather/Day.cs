namespace shop.Models.Weather
{
    public class Day
    {
        public int Icon {get; set;}
        public string IconPhase {get; set;}
        public LocalSource LocalSource {get; set;}
        public bool HasPrecipitation {get; set;}
        public string PrecipitationIntensity {get; set;}
        public string ShortPhase {get; set;}
        public string LongPhrase { get; set; }
        public int PrecipitationProbability { get; set; }
        public int ThunderstormProbability { get; set; }
        public int RainProbability { get; set; }
        public int SnowProbability { get; set; }
        public int IceProbability { get; set; }
        public Wind Wind  { get; set; }
        public WindGust WindGust  { get; set; }
        public TotalLiquid TotalLiquid { get; set; }
        public Rain Rain { get; set; }
        public Snow Snow { get; set; }
        public Ice Ice { get; set; }
        public float HoursOfPrecipitation { get; set; }
        public float HoursOfRain { get; set; }
        public int CloudCover { get; set; }
        public Evapotranspiration Evapotranspiration { get; set; }
        public SolarIrradiance SolarIrradiance { get; set; }

    }
}