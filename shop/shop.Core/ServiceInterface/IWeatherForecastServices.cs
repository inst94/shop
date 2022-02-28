using shop.Core.Dtos.Weather;
using System.Threading.Tasks;

namespace shop.Core.ServiceInterface
{
    public interface IWeatherForecastServices
    {
        Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto);
        WeatherResultDto GetForecast(string city);
    }
}
