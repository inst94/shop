using Microsoft.AspNetCore.Mvc;
using shop.Core.Dtos.OpenWeather;
using shop.Core.ServiceInterface;
using shop.Models.OpenWeather;

namespace shop.Controllers
{
    public class OpenWeatherController : Controller
    {
        private readonly IOpenWeatherForecastServices _openweatherForecastServices;
        public OpenWeatherController
            (
                IOpenWeatherForecastServices openweatherForecastServices
            )
        {
            _openweatherForecastServices = openweatherForecastServices;
        }
        [HttpGet]
        public IActionResult OpenSearchCity()
        {
            OpenSearchCity vm1 = new OpenSearchCity();
            return View(vm1);
        }
        [HttpPost]
        public IActionResult OpenSearchCity(OpenSearchCity model1)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("OpenCity", "OpenWeather", new { opencity = model1.OpenCityName });
            }
            return View(model1);
        }
        [HttpGet]
        public IActionResult OpenCity(string opencity)
        {
            OpenWeatherResultDto dto1 = new OpenWeatherResultDto();

            _openweatherForecastServices.OpenWeatherDetail(dto1);

            OpenCityViewModel model1 = new OpenCityViewModel();

            model1.CoordLon = dto1.CoordLon;
            model1.CoordLat = dto1.CoordLat;

            model1.WeatherId = dto1.WeatherId;
            model1.WeatherMain = dto1.WeatherMain;
            model1.WeatherDescription = dto1.WeatherDescription;
            model1.WeatherIcon = dto1.WeatherIcon;

            model1.Base = dto1.Base;

            model1.MainTemp = dto1.MainTemp;
            model1.MainFeels_Like = dto1.MainFeels_Like;
            model1.MainTemp_Min = dto1.MainTemp_Min;
            model1.MainTemp_Max = dto1.MainTemp_Max;
            model1.MainPressure = dto1.MainPressure;
            model1.MainHumidity = dto1.MainHumidity;

            model1.Visibility = dto1.Visibility;

            model1.WindSpeed = dto1.WindSpeed;
            model1.WindDeg = dto1.WindDeg;

            model1.CloudsAll = dto1.CloudsAll;

            model1.Dt = dto1.Dt;

            model1.SysType = dto1.SysType;
            model1.SysId = dto1.SysId;
            model1.SysMessage = dto1.SysMessage;
            model1.SysCountry = dto1.SysCountry;
            model1.SysSunrise = dto1.SysSunrise;
            model1.SysSunset = dto1.SysSunset;

            model1.Timezone = dto1.Timezone;
            model1.Id = dto1.Id;
            model1.Name = dto1.Name;
            model1.Cod = dto1.Cod;

            return View(model1);
        }
    }
}
