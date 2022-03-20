using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCData.Data;
using MVCData.Models;

namespace MVCData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        private readonly PeopleContext _context;

        public ReactController(PeopleContext context)
        {
            _context = context;
        }

        // GET: api/React
        [HttpGet]
        public async Task<ActionResult<string>> GetPeople()
        {
            List<Person> personApiList = await _context.People.ToListAsync();
            List<City> cityApiList = await _context.Cities.ToListAsync();
            List<Country> countryApiList = await _context.Countries.ToListAsync();
            List<PersonDTO> personDTOApiList = new List<PersonDTO>();

            foreach(Person person in personApiList)
            {
                PersonDTO personDTO = new PersonDTO();

                personDTO.PersonDTOId = person.PersonId;
                personDTO.PersonDTOName = person.Name;
                personDTO.PersonDTOPhone = person.PhoneNumber;

                City city = cityApiList.Where(c => c.CityId == person.CityId).SingleOrDefault();
                personDTO.PersonDTOCity = city.CityName;

                Country country = countryApiList.Where(c => c.CountryId == city.CountryId).SingleOrDefault();

                personDTO.PersonDTOCountry = country.CountryName;

                personDTOApiList.Add(personDTO);
            }

            string personDTOJson = JsonSerializer.Serialize(personDTOApiList);

            return personDTOJson;
        }

        // GET: api/React/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetPerson(int id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            List<PersonLanguage> languageOwners = await _context.PersonLanguages.ToListAsync();
            List<LanguagesDTO> languagesDTOApiList = new List<LanguagesDTO>();

            foreach(PersonLanguage plang in languageOwners)
            {
                LanguagesDTO languagesDTO = new LanguagesDTO();

                if (person.PersonId == plang.PersonRefId)
                {
                     Language language = _context.Languages.Where(i => i.LanguageId == plang.LanguageRefId).SingleOrDefault();

                    languagesDTO.LanguageName = language.LanguageName;

                    languagesDTOApiList.Add(languagesDTO);
                }
            }

            string languagesDTOJson = JsonSerializer.Serialize(languagesDTOApiList);

            return languagesDTOJson;
        }

        // PUT: api/React/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/React
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.PersonId }, person);
        }

        // DELETE: api/React/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return person;
        }

        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.PersonId == id);
        }
    }
}
