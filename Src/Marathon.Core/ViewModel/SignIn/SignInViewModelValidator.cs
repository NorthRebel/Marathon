using FluentValidation;

namespace Marathon.Core.ViewModel.SignIn
{
    /// <summary>
    /// Validation rules for properties of <see cref="SignInViewModel"/>
    /// </summary>
    public class SignInViewModelValidator : AbstractValidator<SignInViewModel>
    {
        public SignInViewModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Строка не соответствует шаблону \"user@mail.com\"");

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
