using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCData.Data;
using MVCData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Controllers
{
    public class CityController : Controller
    {
        private readonly PeopleContext _peopleContext;

        public CityController(PeopleContext peopleContext)
        {
            _peopleContext = peopleContext;
        }

        public IActionResult Cities()
        {
            CitiesViewModel citiesViewModel = new CitiesViewModel();

            citiesViewModel.AllCitiesList = _peopleContext.Cities.Include(c => c.Country).ToList();

            return View(citiesViewModel);
        }
    }
}
