using FluentValidation;

namespace Marathon.Application.Users.Commands.Login
{
    /// <summary>
    /// Rules for arguments of <see cref="LoginUserCommand"/> to right complete them
    /// </summary>
    public sealed class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
