using System.Text.RegularExpressions;
using FluentValidation;

namespace Marathon.Application.Users.Commands.SignUp
{
    /// <summary>
    /// Rules for arguments of <see cref="SignUpCommand"/> to right complete them
    /// </summary>
    public sealed class SignUpCommandValidator : AbstractValidator<SignUpCommand>
    {
        private readonly Regex _upperLetterRegex = new Regex("[A-Z]+");
        private readonly Regex _specialSymbolRegex = new Regex("[!@#$%^]");

        public SignUpCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .Matches(_upperLetterRegex)
                // TODO: Match to one digit!
                .Matches(_specialSymbolRegex);
            RuleFor(x => x.DateOfBirth)
                // TODO: Add age check
                .NotEmpty();
            RuleFor(x => x.CountryId)
                .NotEmpty();
            RuleFor(x => x.GenderId)
                .NotEmpty();
            RuleFor(x => x.FirstName)
                .NotEmpty();
            RuleFor(x => x.LastName)
                .NotEmpty();
            RuleFor(x => x.Photo)
                .NotEmpty();
        }
    }
}
