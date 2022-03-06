using System;

namespace shop.Models.OpenWeather
{
    public class OpenCityViewModel
    {
        public double CoordLon { get; set; }
        public double CoordLat { get; set; }
        public int WeatherId { get; set; }
        public string WeatherMain { get; set; }
        public string WeatherDescription { get; set; }
        public string WeatherIcon { get; set; }
        public string Base { get; set; }
        public double MainTemp { get; set; }
        public double MainFeels_Like { get; set; }
        public double MainTemp_Min { get; set; }
        public double MainTemp_Max { get; set; }
        public int MainPressure { get; set; }
        public int MainHumidity { get; set; }
        public int Visibility { get; set; }
        public double WindSpeed { get; set; }
        public int WindDeg { get; set; }
        public int CloudsAll { get; set; }
        public int Dt { get; set; }
        public int SysType { get; set; }
        public int SysId { get; set; }
        public double SysMessage { get; set; }
        public string SysCountry { get; set; }
        public int SysSunrise { get; set; }
        public int SysSunset { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}
