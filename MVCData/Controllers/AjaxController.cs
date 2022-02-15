using Microsoft.AspNetCore.Mvc;
using MVCData.Data;
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
        private readonly PeopleContext _peopleContext;

        public AjaxController(PeopleContext peopleContext)
        {
            _peopleContext = peopleContext;
        }

        public IActionResult PeopleList()
        {
            List<Person> peopleList = _peopleContext.People.ToList();

            return PartialView("_PeopleList", peopleList);
        }

        [HttpPost]
        public IActionResult PeopleWithId(int id)
        {
            List<Person> personByIdList = new List<Person>();

            int index = 0;
            foreach(Person person in _peopleContext.People)
            {
                if (person.PersonId == id)
                    personByIdList.Add(person);

                index++;
            }

            return PartialView("_PeopleList", personByIdList);
        }

        public IActionResult DeletePeopleWithId(int id)
        {
            bool personFound = false;

            var personToBeDeleted = _peopleContext.People.Find(id);

            if(personToBeDeleted != null)
            {
                _peopleContext.People.Remove(personToBeDeleted);
                _peopleContext.SaveChanges();
                personFound = true;
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
