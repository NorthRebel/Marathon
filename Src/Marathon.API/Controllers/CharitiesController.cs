using System;
using System.Net;
using Marathon.API.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Marathon.API.Models.Charity;

namespace Marathon.API.Controllers
{
    [Route("[controller]")]
    public class CharitiesController : Controller
    {
        private readonly ICharityService _charityService;

        public CharitiesController(ICharityService charityService)
        {
            _charityService = charityService;
        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(typeof(IEnumerable<Charity>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Charity> charities = await _charityService.GetAllAsync();

            return Ok(charities);
        }

        [HttpGet]
        [Route("About/{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(AboutCharity), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AboutCharity(int id)
        {
            if (id <= default(int))
                return BadRequest();

            try
            {
                AboutCharity aboutCharity = await _charityService.AboutCharity(id);

                return Ok(aboutCharity);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
