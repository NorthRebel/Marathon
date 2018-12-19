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
                .WithMessage("Test 1")
                .EmailAddress()
                .WithMessage("Test 2");
        }
    }
}
