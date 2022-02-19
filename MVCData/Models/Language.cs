using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    [Table("Languages")]
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        [Required]
        [Column("Språk")]
        [StringLength(30)]
        public string LanguageName { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; }
    }
}
