using Microsoft.AspNetCore.Mvc;
using MVCData.Models;
using MVCData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult PeopleList()
        {
            List<Person> peopleList = Person.AllPersons;

            return PartialView("_PeopleList", peopleList);
        }

        [HttpPost]
        public IActionResult PeopleWithId(int id)
        {
            List<Person> personByIdList = new List<Person>();

            int index = 0;
            foreach(Person person in Person.AllPersons)
            {
                if (Person.AllPersons[index].PersonId == id)
                    personByIdList.Add(person);

                index++;
            }

            return PartialView("_PeopleList", personByIdList);
        }

        public IActionResult DeletePeopleWithId(int id)
        {
            bool personFound = false;

            int index = 0;
            foreach (Person person in Person.AllPersons)
            {
                if (Person.AllPersons[index].PersonId == id)
                {
                    Person.DeletePerson(id);
                    personFound = true;
                    break;
                }

                index++;
            }

            if(personFound == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
