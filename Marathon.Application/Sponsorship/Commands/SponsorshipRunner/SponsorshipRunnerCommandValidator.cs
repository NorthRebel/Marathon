using FluentValidation;

namespace Marathon.Application.Sponsorship.Commands.SponsorshipRunner
{
    /// <summary>
    /// Rules for arguments of <see cref="SponsorshipRunnerCommand"/> to right complete them
    /// </summary>
    public sealed class SponsorshipRunnerCommandValidator : AbstractValidator<SponsorshipRunnerCommand>
    {
        public SponsorshipRunnerCommandValidator()
        {
            RuleFor(x => x.SponsorName)
                .NotEmpty();
            RuleFor(x => x.RunnerMarathonSignUpId)
                .NotEmpty();
            RuleFor(x => x.Amount)
                .NotEmpty()
                .GreaterThan(default(decimal));
            RuleFor(x => x.CardCredentials)
                .NotNull()
                .SetValidator(new CardCredentialsValidator());
        }
    }
}
