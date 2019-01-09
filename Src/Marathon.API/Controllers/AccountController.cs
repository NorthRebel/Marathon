using System;
using System.Net;
using Marathon.API.Services;
using System.Threading.Tasks;
using Marathon.API.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace Marathon.API.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route(nameof(SignIn))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UserInfo),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> SignIn([FromBody]UserSignInCredentials credentials)
        {
            if (credentials == null)
                return BadRequest();

            try
            {
                UserInfo result = await _userService.SignInAsync(credentials);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route(nameof(SignUp))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UserInfo),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> SignUp([FromBody]UserSignUpCredentials credentials)
        {
            if (credentials == null)
                return BadRequest();

            try
            {
                UserInfo result = await _userService.SignUpAsync(credentials);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
