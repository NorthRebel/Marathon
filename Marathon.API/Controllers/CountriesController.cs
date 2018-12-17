using System.Net;
using Microsoft.AspNetCore.Mvc;
using Marathon.API.Authentication;
using Marathon.API.Models.Country;
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
        [ProducesResponseType(typeof(Countries), (int)HttpStatusCode.OK)]
        public IActionResult GetAll()
        {
            var countries = _countryRepository.GetAllNames();

            return Ok(countries);
        }
    }
}
