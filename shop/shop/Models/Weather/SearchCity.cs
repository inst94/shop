using System.ComponentModel.DataAnnotations;

namespace shop.Models.Weather
{
    public class SearchCity
    {
        [Required(ErrorMessage ="You must enter city name!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage ="Only text allowed")]
        [Display(Name = "City Name")]
        public string CityName { get; set; }
    }
}
