using System;
using System.Text.RegularExpressions;
using FluentValidation;

namespace Marathon.Application.Users.Commands.Register
{
    /// <summary>
    /// Rules for arguments of <see cref="RegisterRunnerCommand"/> to right complete them
    /// </summary>
    public sealed class RegisterRunnerCommandValidator : AbstractValidator<RegisterRunnerCommand>
    {
        private readonly Regex _upperLetterRegex = new Regex("[A-Z]+");
        private readonly Regex _specialSymbolRegex = new Regex("[!@#$%^]");

        public RegisterRunnerCommandValidator()
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
