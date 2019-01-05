using FluentValidation;

namespace Marathon.Core.ViewModel.SignUpToMarathon
{
    /// <summary>
    /// Validation rules for properties of <see cref="SponsorshipDetailsViewModel"/>
    /// </summary>
    public class SponsorshipDetailsViewModelValidator : AbstractValidator<SponsorshipDetailsViewModel>
    {
        public SponsorshipDetailsViewModelValidator()
        {
            RuleFor(x => x.SponsorshipAmount)
                .NotEmpty();

            When(x => x.SponsorshipAmount.HasValue, () =>
            {
                RuleFor(x => x.SponsorshipAmount)
                    .Must(x => x.Value > 0)
                    .WithMessage("Cумма взноса должна быть действительным положительным числом");
            });
        }
    }
}
