using Nancy.Json;
using shop.Core.Dtos.OpenWeather;
using shop.Core.ServiceInterface;
using System.Net;
using System.Threading.Tasks;

namespace shop.ApplicatonServices.Services
{
    public class OpenWeatherForecastServices : IOpenWeatherForecastServices
    {
        public async Task<OpenWeatherResultDto> OpenWeatherDetail(OpenWeatherResultDto dto1)
        {
            var open_url = $"https://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&appid=d38a59db9ef99824a6462860f9a4dee3";

            using (WebClient client1 = new WebClient())
            {
                string json1 = client1.DownloadString(open_url);
                OpenWeatherRootDto openweatherInfo = (new JavaScriptSerializer()).Deserialize<OpenWeatherRootDto>(json1);

                dto1.CoordLon = openweatherInfo.Coord.Lon;
                dto1.CoordLat = openweatherInfo.Coord.Lat;

                dto1.WeatherId = openweatherInfo.Weather[0].Id;
                dto1.WeatherMain = openweatherInfo.Weather[0].Main;
                dto1.WeatherDescription = openweatherInfo.Weather[0].Description;
                dto1.WeatherIcon = openweatherInfo.Weather[0].Icon;

                dto1.Base = openweatherInfo.Base;

                dto1.MainTemp = openweatherInfo.Main.Temp;
                dto1.MainFeels_Like = openweatherInfo.Main.Feels_like;
                dto1.MainTemp_Min = openweatherInfo.Main.Temp_min;
                dto1.MainTemp_Max = openweatherInfo.Main.Temp_max;
                dto1.MainPressure = openweatherInfo.Main.Pressure;
                dto1.MainHumidity = openweatherInfo.Main.Humidity;

                dto1.Visibility = openweatherInfo.Visibility;

                dto1.WindSpeed = openweatherInfo.Wind.Speed;
                dto1.WindDeg = openweatherInfo.Wind.Deg;

                dto1.CloudsAll = openweatherInfo.Clouds.All;

                dto1.Dt = openweatherInfo.Dt;

                dto1.SysType = openweatherInfo.Sys.Type;
                dto1.SysId = openweatherInfo.Sys.Id;
                dto1.SysMessage = openweatherInfo.Sys.Message;
                dto1.SysCountry = openweatherInfo.Sys.Country;
                dto1.SysSunrise = openweatherInfo.Sys.Sunrise;
                dto1.SysSunset = openweatherInfo.Sys.Sunset;

                dto1.Timezone = openweatherInfo.Timezone;
                dto1.Id = openweatherInfo.Id;
                dto1.Name = openweatherInfo.Name;
                dto1.Cod = openweatherInfo.Cod;

                var jsonString1 = new JavaScriptSerializer().Serialize(dto1);
            }
            return dto1;
        }
    }
}
