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
    public class CityController : Controller
    {
        public static string deleteAddCityMessage = null;

        private readonly PeopleContext _peopleContext;

        public CityController(PeopleContext peopleContext)
        {
            _peopleContext = peopleContext;
        }

        public IActionResult Cities()
        {
            CitiesViewModel citiesViewModel = new CitiesViewModel();

            citiesViewModel.AllCitiesList = _peopleContext.Cities.Include(c => c.Country).ToList();
            citiesViewModel.AllCountriesList = _peopleContext.Countries.ToList();

            ViewBag.deleteAddCityMsg = deleteAddCityMessage;

            deleteAddCityMessage = null;

            return View(citiesViewModel);
        }

        [HttpPost]
        public IActionResult Cities(CitiesViewModel inputCitiesModel)
        {
            if (ModelState.IsValid)
            {
                CitiesViewModel citiesViewModel = new CitiesViewModel();

                City createdCity = citiesViewModel.CreateCity(inputCitiesModel.CityName, inputCitiesModel.CountryId);

                _peopleContext.Cities.Add(createdCity);
                _peopleContext.SaveChanges();

                deleteAddCityMessage = "Staden lades till!";

                return RedirectToAction("Cities");
            }
            else
            {
                CitiesViewModel citiesViewModel = new CitiesViewModel();

                citiesViewModel.AllCitiesList = _peopleContext.Cities.Include(c => c.Country).ToList();
                citiesViewModel.AllCountriesList = _peopleContext.Countries.ToList();

                return View(citiesViewModel);
            }
        }

        public IActionResult Delete()
        {
            CitiesViewModel citiesViewModel = new CitiesViewModel();

            citiesViewModel.AllCitiesList = _peopleContext.Cities.ToList();

            return View(citiesViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int cityId)
        {
            if (ModelState.IsValid)
            {
                var city = _peopleContext.Cities.Find(cityId);

                _peopleContext.Cities.Remove(city);
                _peopleContext.SaveChanges();
            }

            deleteAddCityMessage = "Staden togs bort!";

            return RedirectToAction("Cities");
        }
    }
}
