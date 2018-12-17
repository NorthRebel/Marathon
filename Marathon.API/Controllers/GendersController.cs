using System.Net;
using Microsoft.AspNetCore.Mvc;
using Marathon.API.Authentication;
using Marathon.API.Models.Gender;
using Marathon.API.Repositories.Interfaces;

namespace Marathon.API.Controllers
{
    [AuthorizeToken]
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
        [ProducesResponseType(typeof(Genders), (int)HttpStatusCode.OK)]
        public IActionResult GetAll()
        {
            var genders = _genderRepository.GetAllNames();

            return Ok(genders);
        }
    }
}
