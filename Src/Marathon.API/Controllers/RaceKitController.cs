using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Marathon.API.Models.RaceKit;
using Marathon.API.Repositories.Interfaces;

namespace Marathon.API.Controllers
{
    [Route("[controller]")]
    public class RaceKitController : Controller
    {
        private readonly IRaceKitRepository _raceKitRepository;

        public RaceKitController(IRaceKitRepository raceKitRepository)
        {
            _raceKitRepository = raceKitRepository;
        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(typeof(IEnumerable<RaceKit>), (int)HttpStatusCode.OK)]
        public IActionResult All()
        {
            IEnumerable<RaceKit> raceKits = _raceKitRepository.GetAllRaceKits();

            return Ok(raceKits);
        }
    }
}
