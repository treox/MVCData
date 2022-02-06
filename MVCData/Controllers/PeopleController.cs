using Microsoft.AspNetCore.Mvc;
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

        public IActionResult People()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();
            peopleViewModel.AllPersonsList = Person.AllPersons;

            ViewBag.AddedPersonMessage = addMessage;
            ViewBag.DeletedPersonMessage = deleteMessage;

            addMessage = null;
            deleteMessage = null;

            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult People(CreatePersonViewModel createPersonViewModel, string searchedName)
        {
            if(searchedName != null){

                PeopleViewModel peopleViewModel = new PeopleViewModel();

                Person.ReturnByNameOrCity(searchedName);

                peopleViewModel.AllPersonsWithSpcificName = Person.byNameList;

                return View(peopleViewModel);
            }
            else
            {
                if (ModelState.IsValid)
                {
                CreatePersonViewModel createPerson = new CreatePersonViewModel();
                Person returnedPerson = createPerson.CreatePerson(createPersonViewModel.PersonName, createPersonViewModel.Phone, createPersonViewModel.City);

                    Person.AllPersons.Add(returnedPerson);

                    addMessage = "Personen har lagts till!";

                    return RedirectToAction("People");
                }
                else
                {
                    PeopleViewModel peopleViewModel = new PeopleViewModel();
                    peopleViewModel.AllPersonsList = Person.AllPersons;

                    return View(peopleViewModel);
                }
            }
        }

        public IActionResult Delete(int id)
        {
            Person.DeletePerson(id);

            deleteMessage = "Personen har raderats!";

            return RedirectToAction("People");
        }
    }
}
