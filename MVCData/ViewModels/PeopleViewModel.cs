using MVCData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.ViewModels
{
    public class PeopleViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Namn måste anges!")]
        [Display(Name = "Namn")]
        [StringLength(30)]
        public string PersonName { get; set; }
        [Required(ErrorMessage = "Telefonnummer måste anges!")]
        [Display(Name = "Telefon")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(25)]
        public string Phone { get; set; }
        public int CityId { get; set; }
        public int LanguageId { get; set; }

        public Person Person { get; set; }

        public List<Person> AllPersonsList { get; set; }
        public List<Person> AllPersonsWithSpecificNameOrCity { get; set; }
        public List<City> AllCitiesList { get; set; }
        public List<Language> AllLanguagesList { get; set; }

        public Person CreatePerson(string name, string phone, int cityId)
        {
            Person newPerson = new Person()
            {
                Name = name,
                PhoneNumber = phone,
                CityId = cityId
            };

            return newPerson;
        }
    }
}
