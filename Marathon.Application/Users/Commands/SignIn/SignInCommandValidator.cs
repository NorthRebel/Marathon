using FluentValidation;

namespace Marathon.Application.Users.Commands.SignIn
{
    /// <summary>
    /// Rules for arguments of <see cref="SignInCommand"/> to right complete them
    /// </summary>
    public sealed class SignInCommandValidator : AbstractValidator<SignInCommand>
    {
        public SignInCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
