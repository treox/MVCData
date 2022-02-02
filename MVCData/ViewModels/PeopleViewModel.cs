using MVCData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.ViewModels
{
    public class PeopleViewModel
    {
        public string SearchedName { get; set; }

        public List<Person> AllPersonsList { get; set; }

        public List<Person> AllPersonsWithSpcificName { get; set; }
    }
}
