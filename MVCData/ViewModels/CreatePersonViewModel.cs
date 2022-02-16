using MVCData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.ViewModels
{
    public class CreatePersonViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Namn måste anges!")]
        [Display(Name = "Namn")]
        [StringLength(30)]
        public string PersonName {get; set; }
        [Required(ErrorMessage = "Telefonnummer måste anges!")]
        [Display(Name = "Telefon")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(25)]
        public string Phone { get; set; }

        public Person CreatePerson(string name, string phone)
        {
            Person newPerson = new Person()
            {
                Name = name,
                PhoneNumber = phone,
                CityId = 1
            };

            return newPerson;
        }
    }
}
