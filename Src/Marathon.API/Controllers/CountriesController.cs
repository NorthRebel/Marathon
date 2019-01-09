using System.Net;
using Marathon.API.Models;
using Marathon.API.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Marathon.API.Controllers
{
    [Route("[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(typeof(IEnumerable<Country>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Country> countries = await _countryService.GetAllAsync();

            return Ok(countries);
        }
    }
}
