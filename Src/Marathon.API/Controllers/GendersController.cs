using System.Net;
using Marathon.API.Models;
using Marathon.API.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Marathon.API.Controllers
{
    [Route("[controller]")]
    public class GendersController : Controller
    {
        private readonly IGenderService _genderService;

        public GendersController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(typeof(IEnumerable<Gender>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Gender> genders = await _genderService.GetAllAsync();

            return Ok(genders);
        }
    }
}
