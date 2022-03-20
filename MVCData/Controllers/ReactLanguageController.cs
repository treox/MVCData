using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCData.Data;
using MVCData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVCData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactLanguageController : ControllerBase
    {
        private readonly PeopleContext _context;

        public ReactLanguageController(PeopleContext context)
        {
            _context = context;
        }

        // GET: api/ReactLanguage
        [HttpGet]
        public async Task<ActionResult<string>> GetCountries()
        {
            List<Language> languageApiList = await _context.Languages.ToListAsync();

            string languagesJson = JsonSerializer.Serialize(languageApiList);

            return languagesJson;
        }

        // POST: api/ReactLanguage
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(PersonLanguage personLanguage)
        {
            _context.PersonLanguages.Add(personLanguage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonLanguage", new { id = personLanguage.PersonLanguageId }, personLanguage);
        }
    }
}
