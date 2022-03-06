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
            OpenSearchCity vm = new OpenSearchCity();
            return View(vm);
        }
        [HttpPost]
        public IActionResult OpenSearchCity(OpenSearchCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "Weather", new { opencity = model.OpenCityName });
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult OpenCity(string opencity)
        {
            OpenWeatherResultDto dto = new OpenWeatherResultDto();

            _openweatherForecastServices.OpenWeatherDetail(dto);

            OpenCityViewModel model = new OpenCityViewModel();

            model.CoordLon = dto.CoordLon;
            model.CoordLat = dto.CoordLat;

            model.WeatherId = dto.WeatherId;
            model.WeatherMain = dto.WeatherMain;
            model.WeatherDescription = dto.WeatherDescription;
            model.WeatherIcon = dto.WeatherIcon;

            model.Base = dto.Base;

            model.MainTemp = dto.MainTemp;
            model.MainFeels_Like = dto.MainFeels_Like;
            model.MainTemp_Min = dto.MainTemp_Min;
            model.MainTemp_Max = dto.MainTemp_Max;
            model.MainPressure = dto.MainPressure;
            model.MainHumidity = dto.MainHumidity;

            model.Visibility = dto.Visibility;

            model.WindSpeed = dto.WindSpeed;
            model.WindDeg = dto.WindDeg;

            model.CloudsAll = dto.CloudsAll;

            model.Dt = dto.Dt;

            model.SysType = dto.SysType;
            model.SysId = dto.SysId;
            model.SysMessage = dto.SysMessage;
            model.SysCountry = dto.SysCountry;
            model.SysSunrise = dto.SysSunrise;
            model.SysSunset = dto.SysSunset;

            model.Timezone = dto.Timezone;
            model.Id = dto.Id;
            model.Name = dto.Name;
            model.Cod = dto.Cod;

            return View(model);
        }
    }
}
