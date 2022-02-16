using Microsoft.AspNetCore.Mvc;
using MVCData.Data;
using MVCData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Controllers
{
    public class CountryController : Controller
    {
        private readonly PeopleContext _peopleContext;

        public CountryController(PeopleContext peopleContext)
        {
            _peopleContext = peopleContext;
        }

        public IActionResult Countries()
        {
            CountriesViewModel countriesViewModel = new CountriesViewModel();

            countriesViewModel.AllCountriesList = _peopleContext.Countries.ToList();

            return View(countriesViewModel);
        }
    }
}
