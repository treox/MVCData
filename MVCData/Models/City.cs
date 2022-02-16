using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    [Table("Cities")]
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        [Column("Namn")]
        [StringLength(30)]
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public List<Person> People { get; set; }
    }
}
