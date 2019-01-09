using System.Net;
using Marathon.API.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Marathon.API.Authentication;
using Marathon.API.Models.Marathon;
using Microsoft.AspNetCore.Authorization;

namespace Marathon.API.Controllers
{
    [AuthorizeToken]
    [Route("[controller]")]
    public class MarathonController : Controller
    {
        private readonly IMarathonService _marathonService;

        public MarathonController(IMarathonService marathonService)
        {
            _marathonService = marathonService;
        }

        [HttpGet]
        [Route("EventTypes")]
        [ProducesResponseType(typeof(IEnumerable<EventType>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> EventTypes()
        {
            IEnumerable<EventType> eventTypes = await _marathonService.GetEventTypes();

            return Ok(eventTypes);
        }

        [HttpPost]
        [Route(nameof(SignUp))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SignUp([FromBody]MarathonSignUp signUpCredentials)
        {
            if (signUpCredentials == null)
                return BadRequest();

            try
            {
                int marathonSignUpId = await _marathonService.SignUp(signUpCredentials);

                return Ok(marathonSignUpId);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("StartupDate")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(StartupDate), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetStartupDate()
        {
            try
            {
                StartupDate result = await _marathonService.GetStartupDate();

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
