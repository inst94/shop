using Nancy.Json;
using shop.Core.Dtos.Weather;
using shop.Core.ServiceInterface;
using System.Net;
using System.Threading.Tasks;

namespace shop.ApplicatonServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
        {
            //string apikey = "4nbvcd1JKVpDaVXUSZ39suC57SdfvcXX";
            //var locationKey = "127964";
            //connection string
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey=4nbvcd1JKVpDaVXUSZ39suC57SdfvcXX&metric=true";

            using (WebClient client = new ())
            {
                string json = client.DownloadString(url);
                WeatherRootDto weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherRootDto>(json);

                dto.EffectiveDate = weatherInfo.Headline.EffectiveDate;
                dto.EffectiveEpochDate = weatherInfo.Headline.EffectiveEpochDate;
                dto.Severity = weatherInfo.Headline.Severity;
                dto.Text = weatherInfo.Headline.Text;
                dto.Category = weatherInfo.Headline.Category;
                dto.EndDate = weatherInfo.Headline.EndDate;
                dto.EndEpochDate = weatherInfo.Headline.EndEpochDate;

                dto.MobileLink = weatherInfo.Headline.MobileLink;
                dto.Link = weatherInfo.Headline.Link;

                dto.TempMinValue = weatherInfo.DailyForecasts[0].Temperature.Minimum.Value;
                dto.TempMinUnit = weatherInfo.DailyForecasts[0].Temperature.Minimum.Unit;
                dto.TempMinUnitType = weatherInfo.DailyForecasts[0].Temperature.Minimum.UnitType;

                dto.TempMaxValue = weatherInfo.DailyForecasts[0].Temperature.Maximum.Value;
                dto.TempMaxUnit = weatherInfo.DailyForecasts[0].Temperature.Maximum.Unit;
                dto.TempMaxUnitType = weatherInfo.DailyForecasts[0].Temperature.Maximum.UnitType;

                dto.DayIcon = weatherInfo.DailyForecasts[0].Day.Icon;
                dto.DayIconPhase = weatherInfo.DailyForecasts[0].Day.IconPhase;
                dto.DayHasPrecipitation = weatherInfo.DailyForecasts[0].Day.HasPrecipitation;
                
                dto.NightIcon = weatherInfo.DailyForecasts[0].Night.Icon;
                dto.NightIconPhase = weatherInfo.DailyForecasts[0].Night.IconPhase;
                dto.NightHasPrecipitation = weatherInfo.DailyForecasts[0].Night.HasPrecipitation;
                
                var jsonString = new JavaScriptSerializer().Serialize(dto);
            }
            return dto;
        }
    }

}
