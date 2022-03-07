using shop.Core.Dtos.OpenWeather;
using System.Threading.Tasks;

namespace shop.Core.ServiceInterface
{
    public interface IOpenWeatherForecastServices
    {
        Task<OpenWeatherResultDto> OpenWeatherDetail(OpenWeatherResultDto dto1);
    }
}
