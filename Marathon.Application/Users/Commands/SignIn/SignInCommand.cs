using Marathon.Domain.Entities;
using MediatR;

namespace Marathon.Application.Users.Commands.SignIn
{
    /// <summary>
    /// Try to log in user to system
    /// </summary>
    public sealed class SignInCommand : IRequest<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
