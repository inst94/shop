using System.ComponentModel.DataAnnotations;

namespace shop.Models.OpenWeather
{
    public class OpenSearchCity
    {
        [Required(ErrorMessage ="You must enter city name!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage ="Only text allowed")]
        [Display(Name = "City Name")]
        public string OpenCityName { get; set; }
    }
}
