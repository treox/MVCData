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
    public class LanguageController : Controller
    {
        public static string deleteAddLanguageMessage = null;

        private readonly PeopleContext _peopleContext;

        public LanguageController(PeopleContext peopleContext)
        {
            _peopleContext = peopleContext;
        }

        public IActionResult Languages()
        {
            LanguagesViewModel languagesViewModel = new LanguagesViewModel();

            languagesViewModel.AllPersonsList = _peopleContext.People.ToList();
            languagesViewModel.AllLanguagesList = _peopleContext.Languages.ToList();
            languagesViewModel.AllPersonLanguagesList = _peopleContext.PersonLanguages.ToList();

            ViewBag.deleteAddLanguageMsg = deleteAddLanguageMessage;

            deleteAddLanguageMessage = null;

            return View(languagesViewModel);
        }

        [HttpPost]
        public IActionResult Languages(LanguagesViewModel languagesInputViewModel, int personId, int languageId)
        {
            if(personId != 0 && languageId != 0)
            {
                PersonLanguage newPersonLanguage = new PersonLanguage()
                {
                    PersonRefId = personId,
                    LanguageRefId = languageId
                };

                _peopleContext.PersonLanguages.Add(newPersonLanguage);
                _peopleContext.SaveChanges();

                return RedirectToAction("Languages");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    Language newLanguage = new Language()
                    {
                        LanguageName = languagesInputViewModel.LanguageName
                    };

                    _peopleContext.Languages.Add(newLanguage);
                    _peopleContext.SaveChanges();

                    deleteAddLanguageMessage = "Språket lades till!";

                    return RedirectToAction("Languages");
                }
                else
                {
                    LanguagesViewModel languagesViewModel = new LanguagesViewModel();

                    languagesViewModel.AllPersonsList = _peopleContext.People.ToList();
                    languagesViewModel.AllLanguagesList = _peopleContext.Languages.ToList();
                    languagesViewModel.AllPersonLanguagesList = _peopleContext.PersonLanguages.ToList();

                    return View(languagesViewModel);
                }
            }
        }

        public IActionResult Delete()
        {
            LanguagesViewModel languagesViewModel = new LanguagesViewModel();

            languagesViewModel.AllLanguagesList = _peopleContext.Languages.ToList();

            return View(languagesViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int languageId)
        {
            if (ModelState.IsValid)
            {
                var language = _peopleContext.Languages.Find(languageId);

                _peopleContext.Languages.Remove(language);
                _peopleContext.SaveChanges();
            }

            deleteAddLanguageMessage = "Språket togs bort!";

            return RedirectToAction("Languages");
        }
    }
}
