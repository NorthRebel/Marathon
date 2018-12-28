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
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Строка не соответствует шаблону \"user@mail.com\"");

            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotEmpty();
        }
    }
}
