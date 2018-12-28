using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Marathon.API.Models.Runner;
using Marathon.API.Authentication;
using Marathon.API.Repositories.Interfaces;

namespace Marathon.API.Controllers
{
    [AuthorizeToken]
    [Route("[controller]")]
    public class RunnerController : Controller
    {
        private readonly IRunnerRepository _runnerRepository;

        public RunnerController(IRunnerRepository runnerRepository)
        {
            _runnerRepository = runnerRepository;
        }

        [HttpPost]
        [Route(nameof(SignUp))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public IActionResult SignUp([FromBody]RunnerSignUpCredentials credentials)
        {
            if (credentials == null)
                return BadRequest();

            try
            {
                int runnerId =_runnerRepository.SignUp(credentials);

                return Ok(runnerId);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("Id")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public IActionResult GetId(int userId)
        {
            int runnerId = _runnerRepository.GetId(userId);

            return Ok(runnerId);
        }
    }
}
