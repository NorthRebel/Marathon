using System.Net;
using Marathon.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Marathon.API.Repositories.Interfaces;

namespace Marathon.API.Controllers
{
    [Route("[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(typeof(IEnumerable<Country>), (int)HttpStatusCode.OK)]
        public IActionResult GetAll()
        {
            var countries = _countryRepository.GetAll();

            return Ok(countries);
        }
    }
}
