using MVCData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.ViewModels
{
    public class CountriesViewModel
    {
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Land måste anges!")]
        [Display(Name = "Typ av land")]
        [StringLength(30)]
        public string CountryName { get; set; }

        public List<Country> AllCountriesList { get; set; }
    }
}
