using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    [Table("People")]
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [Column("Namn")]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [Column("Telefonnummer")]
        [StringLength(25)]
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
