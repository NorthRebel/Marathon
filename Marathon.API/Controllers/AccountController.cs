using System;
using System.Net;
using Marathon.API.Models.User;
using Marathon.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Marathon.API.Authentication;
using Marathon.API.Repositories.Interfaces;

namespace Marathon.API.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route(nameof(SignIn))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UserInfo),(int)HttpStatusCode.OK)]
        public IActionResult SignIn([FromBody]UserSignInCredentials credentials)
        {
            if (credentials == null)
                return BadRequest();

            try
            {
                User user = _userRepository.SignIn(credentials);

                var userInfo = new UserInfo
                {
                    Id = user.Id,
                    UserType = user.UserTypeId,
                    Token = user.GenerateJwtToken()
                };

                return Ok(userInfo);
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
        public IActionResult SignUp([FromBody]UserSignUpCredentials credentials)
        {
            if (credentials == null)
                return BadRequest();

            try
            {
                User user = _userRepository.SignUp(credentials);

                var userInfo = new UserInfo
                {
                    Id = user.Id,
                    UserType = user.UserTypeId,
                    Token = user.GenerateJwtToken()
                };

                return Ok(userInfo);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
