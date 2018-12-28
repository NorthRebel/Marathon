using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Marathon.API.Authentication;
using Marathon.API.Models.Marathon;
using Marathon.API.Repositories.Interfaces;

namespace Marathon.API.Controllers
{
    [AuthorizeToken]
    [Route("[controller]")]
    public class MarathonController : Controller
    {
        private readonly IMarathonRepository _marathonRepository;

        public MarathonController(IMarathonRepository marathonRepository)
        {
            _marathonRepository = marathonRepository;
        }

        [HttpGet]
        [Route("EventTypes")]
        [ProducesResponseType(typeof(IEnumerable<EventType>), (int)HttpStatusCode.OK)]
        public IActionResult EventTypes()
        {
            IEnumerable<EventType> eventTypes = _marathonRepository.GetAllEventTypes();

            return Ok(eventTypes);
        }

        [HttpPost]
        [Route(nameof(SignUp))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public IActionResult SignUp([FromBody]MarathonSignUp signUpCredentials)
        {
            if (signUpCredentials == null)
                return BadRequest();

            try
            {
                var marathonSignUpId = _marathonRepository.SignUp(signUpCredentials);

                return Ok(marathonSignUpId);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
