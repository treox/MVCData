using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class PersonDTO
    {
        public int PersonDTOId { get; set; }
        public string PersonDTOName { get; set; }
        public string PersonDTOPhone { get; set; }
        public string PersonDTOCity { get; set; }
        public string PersonDTOCountry { get; set; }
    }
}
