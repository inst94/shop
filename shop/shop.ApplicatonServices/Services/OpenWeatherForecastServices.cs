using Nancy.Json;
using shop.Core.Dtos.OpenWeather;
using shop.Core.ServiceInterface;
using System.Net;
using System.Threading.Tasks;

namespace shop.ApplicatonServices.Services
{
    public class OpenWeatherForecastServices : IOpenWeatherForecastServices
    {
        public async Task<OpenWeatherResultDto> OpenWeatherDetail(OpenWeatherResultDto dto)
        {
            var open_url = $"https://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&appid=d38a59db9ef99824a6462860f9a4dee3";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(open_url);
                OpenWeatherRootDto openweatherInfo = (new JavaScriptSerializer()).Deserialize<OpenWeatherRootDto>(json);

                dto.CoordLon = openweatherInfo.Coord.Lon;
                dto.CoordLat = openweatherInfo.Coord.Lat;

                dto.WeatherId = openweatherInfo.Weather[0].Id;
                dto.WeatherMain = openweatherInfo.Weather[0].Main;
                dto.WeatherDescription = openweatherInfo.Weather[0].Description;
                dto.WeatherIcon = openweatherInfo.Weather[0].Icon;

                dto.Base = openweatherInfo.Base;

                dto.MainTemp = openweatherInfo.Main.Temp;
                dto.MainFeels_Like = openweatherInfo.Main.Feels_like;
                dto.MainTemp_Min = openweatherInfo.Main.Temp_min;
                dto.MainTemp_Max = openweatherInfo.Main.Temp_max;
                dto.MainPressure = openweatherInfo.Main.Pressure;
                dto.MainHumidity = openweatherInfo.Main.Humidity;

                dto.Visibility = openweatherInfo.Visibility;

                dto.WindSpeed = openweatherInfo.Wind.Speed;
                dto.WindDeg = openweatherInfo.Wind.Deg;

                dto.CloudsAll = openweatherInfo.Clouds.All;

                dto.Dt = openweatherInfo.Dt;

                dto.SysType = openweatherInfo.Sys.Type;
                dto.SysId = openweatherInfo.Sys.Id;
                dto.SysMessage = openweatherInfo.Sys.Message;
                dto.SysCountry = openweatherInfo.Sys.Country;
                dto.SysSunrise = openweatherInfo.Sys.Sunrise;
                dto.SysSunset = openweatherInfo.Sys.Sunset;

                dto.Timezone = openweatherInfo.Timezone;
                dto.Id = openweatherInfo.Id;
                dto.Name = openweatherInfo.Name;
                dto.Cod = openweatherInfo.Cod;

                var jsonString = new JavaScriptSerializer().Serialize(dto);
            }
            return dto;
        }
    }
}
