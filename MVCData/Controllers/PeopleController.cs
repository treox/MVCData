using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCData.Data;
using MVCData.Models;
using MVCData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Controllers
{
    [Authorize(Roles = "Admin, User")]
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
            PeopleViewModel peopleViewModel = new PeopleViewModel();

            peopleViewModel.AllPersonsList = _peopleContext.People.Include(c => c.City).ToList();
            peopleViewModel.AllCitiesList = _peopleContext.Cities.Include(c => c.Country).ToList();
            peopleViewModel.AllLanguagesList = _peopleContext.Languages.ToList();

            ViewBag.AddedPersonMessage = addMessage;
            ViewBag.DeletedPersonMessage = deleteMessage;

            addMessage = null;
            deleteMessage = null;

            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult People(PeopleViewModel inputViewModel, string searchedName)
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();

            if(searchedName != null){

                var foundPersonByName = _peopleContext.People.Include(c => c.City).Where(n => n.Name == searchedName).ToList();
                var foundPersonByCity = _peopleContext.People.Include(c => c.City).Where(pc => pc.City.CityName == searchedName).ToList();
                if(foundPersonByName.Count > 0)
                {
                    peopleViewModel.AllPersonsWithSpecificNameOrCity = foundPersonByName;
                    peopleViewModel.AllCitiesList = _peopleContext.Cities.Include(c => c.Country).ToList();

                    return View(peopleViewModel);
                }
                else if(foundPersonByCity.Count > 0)
                {
                    peopleViewModel.AllPersonsWithSpecificNameOrCity = foundPersonByCity;
                    peopleViewModel.AllCitiesList = _peopleContext.Cities.Include(c => c.Country).ToList();

                    return View(peopleViewModel);
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
                    Person returnedPerson = peopleViewModel.CreatePerson(inputViewModel.PersonName, inputViewModel.Phone, inputViewModel.CityId);

                    _peopleContext.People.Add(returnedPerson);
                    _peopleContext.SaveChanges();

                    addMessage = "Personen har lagts till!";

                    return RedirectToAction("People");
                }
                else
                {
                    peopleViewModel.AllPersonsList = _peopleContext.People.Include(c => c.City).ToList();
                    peopleViewModel.AllCitiesList = _peopleContext.Cities.Include(c => c.Country).ToList();

                    return View(peopleViewModel);
                }
            }
        }

        public IActionResult Edit(int id)
        {
            var personToBeEdited = _peopleContext.People.Find(id);

            PeopleViewModel peopleViewModel = new PeopleViewModel();

            peopleViewModel.Person = personToBeEdited;
            peopleViewModel.AllCitiesList = _peopleContext.Cities.ToList();

            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult Edit(PeopleViewModel inputEditModel)
        {
            if (ModelState.IsValid)
            {
                var personToBeEdited = _peopleContext.People.Find(inputEditModel.Id);

                personToBeEdited.Name = inputEditModel.PersonName;
                personToBeEdited.PhoneNumber = inputEditModel.Phone;
                personToBeEdited.CityId = inputEditModel.CityId;

                _peopleContext.People.Update(personToBeEdited);
                _peopleContext.SaveChanges();

                addMessage = "Personen har redigerats!";
                return RedirectToAction("People");
            }
            else
            {
                var personToBeEdited = _peopleContext.People.Find(inputEditModel.Id);

                PeopleViewModel peopleViewModel = new PeopleViewModel();

                peopleViewModel.Person = personToBeEdited;
                peopleViewModel.AllCitiesList = _peopleContext.Cities.ToList();

                return View(peopleViewModel);
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
