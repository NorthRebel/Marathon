using System.Net;
using Marathon.API.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Marathon.API.Models.RaceKit;

namespace Marathon.API.Controllers
{
    [Route("[controller]")]
    public class RaceKitController : Controller
    {
        private readonly IRaceKitService _raceKitService;

        public RaceKitController(IRaceKitService raceKitService)
        {
            _raceKitService = raceKitService;
        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(typeof(IEnumerable<RaceKit>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> All()
        {
            IEnumerable<RaceKit> raceKits = await _raceKitService.GetAll();

            return Ok(raceKits);
        }
    }
}
