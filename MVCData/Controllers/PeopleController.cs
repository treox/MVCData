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
    public class PeopleController : Controller
    {
        public static string addMessage = null;
        public static string deleteMessage = null;

        private readonly PeopleContext _peopleContext;

        public PeopleController(PeopleContext peopleContext)
        {
            _peopleContext = peopleContext;
        }

        public IActionResult People()
        {
            List<Person> persons = _peopleContext.People.ToList();

            ViewBag.AddedPersonMessage = addMessage;
            ViewBag.DeletedPersonMessage = deleteMessage;

            addMessage = null;
            deleteMessage = null;

            return View(persons);
        }

        [HttpPost]
        public IActionResult People(CreatePersonViewModel createPersonViewModel, string searchedName)
        {
            if(searchedName != null){

                var foundPersonByName = _peopleContext.People.Where(n => n.Name == searchedName).ToList();
                var foundPersonByCity = _peopleContext.People.Where(c => c.City == searchedName).ToList();
                if(foundPersonByName.Count > 0)
                {
                    return View(foundPersonByName);
                }
                else if(foundPersonByCity.Count > 0)
                {
                    return View(foundPersonByCity);
                }
                else
                {
                    return RedirectToAction("People");
                }

            }
            else
            {
                if (ModelState.IsValid)
                {
                    CreatePersonViewModel createPerson = new CreatePersonViewModel();
                    Person returnedPerson = createPerson.CreatePerson(createPersonViewModel.PersonName, createPersonViewModel.Phone, createPersonViewModel.City);

                    _peopleContext.People.Add(returnedPerson);
                    _peopleContext.SaveChanges();

                    addMessage = "Personen har lagts till!";

                    return RedirectToAction("People");
                }
                else
                {
                    List<Person> persons = _peopleContext.People.ToList();

                    return View(persons);
                }
            }
        }

        public IActionResult Delete(int id)
        {
            var personToBeDeleted = _peopleContext.People.Find(id);

            if(personToBeDeleted == null)
            {
                deleteMessage = "Personen kunde inte tas bort!";
                return RedirectToAction("People");
            }
            else
            {
                _peopleContext.People.Remove(personToBeDeleted);
                _peopleContext.SaveChanges();

                deleteMessage = "Personen har raderats!";

                return RedirectToAction("People");
            }
        }
    }
}
