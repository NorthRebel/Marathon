using System.Net;
using Marathon.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Marathon.API.Repositories.Interfaces;

namespace Marathon.API.Controllers
{
    [Route("[controller]")]
    public class GendersController : Controller
    {
        private readonly IGenderRepository _genderRepository;

        public GendersController(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(typeof(IEnumerable<Gender>), (int)HttpStatusCode.OK)]
        public IActionResult GetAll()
        {
            var genders = _genderRepository.GetAll();

            return Ok(genders);
        }
    }
}
