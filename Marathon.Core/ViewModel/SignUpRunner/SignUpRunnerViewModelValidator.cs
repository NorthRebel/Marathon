using FluentValidation;
using Marathon.Core.ViewModel.Input;

namespace Marathon.Core.ViewModel.SignUpRunner
{
    /// <summary>
    /// Validation rules for properties of <see cref="SignUpRunnerViewModel"/>
    /// </summary>
    public class SignUpRunnerViewModelValidator : AbstractValidator<SignUpRunnerViewModel>
    {
        public SignUpRunnerViewModelValidator()
        {
            RuleFor(x => x.Email).SetValidator(new EmailValidator());

            RuleFor(x => x.FirstName).SetValidator(new NameValidator());

            RuleFor(x => x.LastName).SetValidator(new NameValidator());
        }
        
        private class EmailValidator : AbstractValidator<EntryViewModel<string>>
        {
            public EmailValidator()
            {
                RuleFor(x => x.Value)
                    .NotEmpty()
                    .EmailAddress()
                    .WithMessage("Строка не соответствует шаблону \"user@mail.com\"");
            }
        }

        private class NameValidator : AbstractValidator<EntryViewModel<string>>
        {
            public NameValidator()
            {
                RuleFor(x => x.Value)
                    .NotEmpty();
            }
        }
    }
}
