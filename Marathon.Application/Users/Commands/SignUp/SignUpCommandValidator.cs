using System;
using System.Linq;
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
                // TODO: Add one digit check (now it's very strange bug)
                //.Must(x => x.Any(char.IsDigit))
                .Matches(_specialSymbolRegex);
            RuleFor(x => x.DateOfBirth)
                .Must(x => AgeMustBeGreaterThan(x, 10));
            RuleFor(x => x.FirstName)
                .NotEmpty();
            RuleFor(x => x.LastName)
                .NotEmpty();
            RuleFor(x => x.Photo)
                .NotEmpty();
        }

        #region Validator Helpers
        
        /// <summary>
        /// Entered date of birth must me greater than...
        /// </summary>
        private bool AgeMustBeGreaterThan(DateTime dateOfBirth, int ageToCompare)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            return age >= ageToCompare;
        }
        
        #endregion
    }
}
