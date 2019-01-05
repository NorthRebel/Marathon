using System;
using System.Linq;
using FluentValidation;

namespace Marathon.Core.ViewModel.SignUpRunner
{
    /// <summary>
    /// Validation rules for properties of <see cref="SignUpRunnerViewModel"/>
    /// </summary>
    public class SignUpRunnerViewModelValidator : AbstractValidator<SignUpRunnerViewModel>
    {
        public SignUpRunnerViewModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotEmpty();

            RuleFor(x => x.CountryId)
                .NotEmpty();

            RuleFor(x => x.GenderId)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Строка не соответствует шаблону \"user@mail.com\"");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                // Special symbols
                .Matches("[!@#$%^]").WithMessage("Пароль должен содержать один из следующих символов: \"! @ # $ % ^\"");

            When(x => !string.IsNullOrEmpty(x.Password), () =>
            {
                RuleFor(x => x.Password)
                    // Minimum one char is digit
                    .Must(x => x.Any(char.IsDigit)).WithMessage("В пароле должна быть как минимум 1 цифра")
                    // Minimum one char is upper case
                    .Must(x => x.Any(char.IsUpper)).WithMessage("В пароле должна быть как минимум 1 буква в верхнем регистре");
            });

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .Equal(x => x.Password)
                .WithMessage("Пароли не совпадают!");

            RuleFor(x => x.BirthDay)
                .NotEmpty()
                .Must(x => AgeMustBeGreaterThan(x, 10)).WithMessage("Возраст должен быть более 10 лет");

            RuleFor(x => x.PhotoPath)
                .NotEmpty().WithMessage("Загрузите свою фотографию");
        }

        #region Validator Helpers

        /// <summary>
        /// Entered date of birth must me greater than...
        /// </summary>
        private bool AgeMustBeGreaterThan(DateTime? dateOfBirth, int ageToCompare)
        {
            if (!dateOfBirth.HasValue)
                return false;

            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Value.Year;
            return age >= ageToCompare;
        }

        #endregion.
    }
}
