using System;
using System.Net;
using Marathon.API.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Marathon.API.Models.Runner;
using Marathon.API.Authentication;

namespace Marathon.API.Controllers
{
    [AuthorizeToken]
    [Route("[controller]")]
    public class RunnerController : Controller
    {
        private readonly IRunnerService _runnerService;

        public RunnerController(IRunnerService runnerService)
        {
            _runnerService = runnerService;
        }

        [HttpPost]
        [Route(nameof(SignUp))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SignUp([FromBody]RunnerSignUpCredentials credentials)
        {
            if (credentials == null)
                return BadRequest();

            try
            {
                int runnerId = await _runnerService.SignUpAsync(credentials);

                return Ok(runnerId);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("Id/{userId}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetId(int userId)
        {
            int runnerId = await _runnerService.GetId(userId);

            return Ok(runnerId);
        }
    }
}
