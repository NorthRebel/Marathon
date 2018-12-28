using FluentValidation;

namespace Marathon.Core.ViewModel.SignUpToMarathon
{
    /// <summary>
    /// Validation rules for properties of <see cref="SignUpToMarathonViewModel"/>
    /// </summary>
    public class SignUpToMarathonViewModelValidator : AbstractValidator<SignUpToMarathonViewModel>
    {
        public SignUpToMarathonViewModelValidator()
        {
            RuleFor(x => x.SelectedMarathonType)
                .NotEmpty()
                .WithMessage("Выберите хотя-бы 1 вид марафона");

            RuleFor(x => x.SelectedRaceKit)
                .NotEmpty()
                .WithMessage("Выберите 1 из вариантов комплекта");
        }
    }
}
