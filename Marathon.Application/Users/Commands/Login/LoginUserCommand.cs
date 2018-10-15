using Marathon.Domain.Entities;
using MediatR;

namespace Marathon.Application.Users.Commands.Login
{
    /// <summary>
    /// Try to log in user to system
    /// </summary>
    public sealed class LoginUserCommand : IRequest<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
