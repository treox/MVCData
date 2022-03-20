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
    public class ReactCityController : ControllerBase
    {
        private readonly PeopleContext _context;

        public ReactCityController(PeopleContext context)
        {
            _context = context;
        }

        // GET: api/ReactCity
        [HttpGet]
        public async Task<ActionResult<string>> GetCountries()
        {
            List<City> cityApiList = await _context.Cities.ToListAsync();

            string citiesJson = JsonSerializer.Serialize(cityApiList);

            return citiesJson;
        }
    }
}
