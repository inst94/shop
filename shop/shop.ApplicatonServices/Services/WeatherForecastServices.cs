using RestSharp;
using shop.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.ApplicatonServices.Services
{
    public class WeatherForecastServices
    {
        public async Task<WeatherDto>WeatherResponse ()
        {
            string idWeather = "4nbvcd1JKVpDaVXUSZ39suC57SdfvcXX";
            //connection string
            var client = new RestClient($"http://www.accuweather.com/et/ee/tallinn/127964/daily-weather-forecast/127964?lang=et-et");
            var client1 = new RestClient($"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey=4nbvcd1JKVpDaVXUSZ39suC57SdfvcXX&language=et-et&details=false&metric=false");

            return null;
        }

    }
}
