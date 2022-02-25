using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        public static string deleteAddCountryMessage = null;

        private readonly PeopleContext _peopleContext;

        public CountryController(PeopleContext peopleContext)
        {
            _peopleContext = peopleContext;
        }

        public IActionResult Countries()
        {
            CountriesViewModel countriesViewModel = new CountriesViewModel();

            countriesViewModel.AllCountriesList = _peopleContext.Countries.ToList();

            ViewBag.deleteAddCountryMsg = deleteAddCountryMessage;

            deleteAddCountryMessage = null;

            return View(countriesViewModel);
        }

        [HttpPost]
        public IActionResult Countries(CountriesViewModel inputCountry)
        {
            if (ModelState.IsValid)
            {
                Country newCountry = new Country()
                {
                    CountryName = inputCountry.CountryName
                };

                _peopleContext.Countries.Add(newCountry);
                _peopleContext.SaveChanges();

                deleteAddCountryMessage = "Landet lades till!";

                return RedirectToAction("Countries");
            }
            else
            {
                CountriesViewModel countriesViewModel = new CountriesViewModel();

                countriesViewModel.AllCountriesList = _peopleContext.Countries.ToList();

                return View(countriesViewModel);
            }
        }

        public IActionResult Delete()
        {
            CountriesViewModel countriesViewModel = new CountriesViewModel();

            countriesViewModel.AllCountriesList = _peopleContext.Countries.ToList();

            return View(countriesViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int countryId)
        {
            if (ModelState.IsValid)
            {
                var country = _peopleContext.Countries.Find(countryId);

                _peopleContext.Countries.Remove(country);
                _peopleContext.SaveChanges();
            }

            deleteAddCountryMessage = "Landet togs bort!";

            return RedirectToAction("Countries");
        }
    }
}
