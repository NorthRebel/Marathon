using FluentValidation;

namespace Marathon.Core.ViewModel.SignUpToMarathon
{
    /// <summary>
    /// Validation rules for properties of <see cref="CharityDetailViewModel"/>
    /// </summary>
    public class CharityDetailViewModelValidator : AbstractValidator<CharityDetailViewModel>
    {
        public CharityDetailViewModelValidator()
        {
            RuleFor(x => x.Charity)
                .NotEmpty()
                .WithMessage("Выберите благотворительную организацию");
        }
    }
}
