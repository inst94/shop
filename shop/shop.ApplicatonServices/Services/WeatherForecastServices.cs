using Nancy.Json;
using RestSharp;
using shop.Core.Dtos;
using shop.Core.Dtos.Weather;
using shop.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace shop.ApplicatonServices.Services
{
    public class WeatherForecastServices
    {
        public async Task<WeatherDto> WeatherResponse ()
        {
            string apikey = "4nbvcd1JKVpDaVXUSZ39suC57SdfvcXX";
            var locationKey = "127964";
            //connection string
            //var url = $"http://www.accuweather.com/et/ee/tallinn/{locationKey}/daily-weather-forecast/{locationKey}?lang=et-et";
            var url2 = new RestClient($"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{locationKey}?apikey={apikey}&language=et-et&details=false&metric=false");

            var request = new RestRequest(Method.GET);
            IRestRequest

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url2);
                DailyForecastDto weatherInfo = (new JavaScriptSerializer()).Deserialize<DailyForecastDto>(json);
                HeadlineDto headlineInfo = (new JavaScriptSerializer()).Deserialize<HeadlineDto>(json);
                WeatherResultDto result = new WeatherResultDto();
                result.EffectiveDate = headlineInfo.EffectiveDate;
                result.EffectiveEpochDate = headlineInfo.EffectiveEpochDate;
                result.Severity = headlineInfo.Severity;
                result.Text = headlineInfo.Text;
                result.Category = headlineInfo.Category;
                result.EndDate = headlineInfo.EndDate;
                result.EndEpochDate = headlineInfo.EndEpochDate;
                result.MobileLink = headlineInfo.MobileLink;
                result.Link = headlineInfo.Link;

                result.Date = weatherInfo.Date;
                result.EpochDate = weatherInfo.EpochDate;

                MinimumDto minimumDto = new MinimumDto();
                result.TempMinValue = minimumDto.Value;
                result.TempMinUnit = minimumDto.Unit;
                result.TempMinUnitType = minimumDto.UnitType;
                MaximumDto maximumDto = new MaximumDto();
                result.TempMaxValue = maximumDto.Value;
                result.TempMaxUnit = maximumDto.Unit;
                result.TempMaxUnitType = maximumDto.UnitType;

                result.DayIcon = weatherInfo.Day.Icon;
                result.DayIconPhase = weatherInfo.Day.IconPhase;
                result.DayHasPrecipitation = weatherInfo.Day.HasPrecipitation;
                result.DayPrecipitationType = weatherInfo.Day.PrecipitationType;
                result.DayPrecipitationIntensity = weatherInfo.Day.PrecipitationIntensity;

                result.NightIcon = weatherInfo.Night.Icon;
                result.NightIconPhase = weatherInfo.Night.IconPhase;
                result.NightHasPrecipitation = weatherInfo.Night.HasPrecipitation;
                result.NightPrecipitationType = weatherInfo.Night.PrecipitationType;
                result.NightPrecipitationIntensity = weatherInfo.Night.PrecipitationIntensity;

                result.Sources = weatherInfo.Sources;

                var jsonString = new JavaScriptSerializer().Serialize(result);
                return jsonString;
            }
            //return null;
        }

    }
}
