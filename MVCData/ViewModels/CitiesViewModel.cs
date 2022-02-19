using MVCData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.ViewModels
{
    public class CitiesViewModel
    {
        public int CityId { get; set; }
        [Required(ErrorMessage = "Stad måste anges!")]
        [Display(Name = "Typ av stad")]
        [StringLength(30)]
        public string CityName { get; set; }
        public int CountryId { get; set; }

        public List<City> AllCitiesList { get; set; }
        public List<Country> AllCountriesList { get; set; }

        public City CreateCity(string cityName, int countryId)
        {
            City newCity = new City()
            {
                CityName = cityName,
                CountryId = countryId
            };

            return newCity;
        }
    }
}
