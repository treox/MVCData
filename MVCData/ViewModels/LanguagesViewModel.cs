using MVCData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.ViewModels
{
    public class LanguagesViewModel
    {
        public int PersonId { get; set; }
        public int LanguageId { get; set; }
        [Required(ErrorMessage = "Namn måste anges!")]
        [Display(Name = "Typ av språk")]
        [StringLength(30)]
        public string LanguageName { get; set; }

        public List<Person> AllPersonsList { get; set; }
        public List<Language> AllLanguagesList { get; set; }
        public List<PersonLanguage> AllPersonLanguagesList { get; set; }
    }
}
