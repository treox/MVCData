using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    [Table("LanguageOwner")]
    public class PersonLanguage
    {
        [Key]
        public int PersonLanguageId { get; set; }
        [ForeignKey("Person")]
        public int PersonRefId { get; set; }
        public Person Person { get; set; }

        [ForeignKey("Language")]
        public int LanguageRefId { get; set; }
        public Language Language { get; set; }
    }
}
