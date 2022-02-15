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
        //private static int tempId = 3;
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
        [Required(ErrorMessage = "Stad måste anges!")]
        [Display(Name = "Stad")]
        [StringLength(30)]
        public string City { get; set; }

        public Person CreatePerson(string name, string phone, string city)
        {
            //tempId = Person.NextId(tempId);

            Person newPerson = new Person()
            {
                //PersonId = tempId,
                Name = name,
                PhoneNumber = phone,
                City = city
            };

            return newPerson;
        }
    }
}
