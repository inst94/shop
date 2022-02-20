using Microsoft.AspNetCore.Mvc;
using shop.Core.Dtos.Weather;
using shop.Core.ServiceInterface;
using shop.Models.Weather;

namespace shop.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherForecastServices _weatherForecastServices;
        public WeatherController
            (
            IWeatherForecastServices weatherForecastServices
            )
        {
            _weatherForecastServices = weatherForecastServices;
        }
        [HttpGet]
        public IActionResult SearchCity()
        {
            SearchCity vm = new SearchCity();
            return View(vm);
        }
        [HttpPost]
        public IActionResult SearchCity(SearchCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "Weather", new { city = model.CityName});
            }
            return View(model);
        }
        public IActionResult City(string city)
        {
            var weatherResponse = _weatherForecastServices.GetResponse(city);
            CityViewModel model = new CityViewModel();
            WeatherResultDto dto = new WeatherResultDto();
            HeadlineDto headlineDto = new HeadlineDto();
            if (weatherResponse != null)
            {
                model.EffectiveDate = headlineDto.EffectiveDate;
                model.EffectiveEpochDate = headlineDto.EffectiveEpochDate;
                model.Severity = headlineDto.Severity;
                model.Text = headlineDto.Text;
                model.Category = headlineDto.Category;
                model.EndDate = headlineDto.EndDate;
                model.EndEpochDate = headlineDto.EndEpochDate;
                model.MobileLink = headlineDto.MobileLink;
                model.Link = headlineDto.Link;

                model.Date = dto.Date;
                model.EpochDate = dto.EpochDate;

                model.TempMinValue = dto.TempMinValue;
                model.TempMinUnit = dto.TempMinUnit;
                model.TempMinUnitType = dto.TempMinUnitType;
                model.TempMaxValue = dto.TempMaxValue;
                model.TempMaxUnit = dto.TempMaxUnit;
                model.TempMaxUnitType = dto.TempMaxUnitType;

                model.DayIcon = dto.DayIcon;
                model.DayIconPhase = dto.DayIconPhase;
                model.DayHasPrecipitation = dto.DayHasPrecipitation;
                model.DayPrecipitationType = dto.DayPrecipitationType;
                model.DayPrecipitationIntensity = dto.DayPrecipitationIntensity;

                model.NightIcon = dto.NightIcon;
                model.NightIconPhase = dto.NightIconPhase;
                model.NightHasPrecipitation = dto.NightHasPrecipitation;
                model.NightPrecipitationType = dto.NightPrecipitationType;
                model.NightPrecipitationIntensity = dto.NightPrecipitationIntensity;

                model.Sources = dto.Sources;
            }
            return View(model);
        }
    }
}
