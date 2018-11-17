using System.Linq;
using FluentValidation;

namespace Marathon.Application.Marathon.Commands.SignUpToMarathon
{
    /// <summary>
    /// Rules for arguments of <see cref="SignUpToMarathonCommand"/> to right complete them
    /// </summary>
    public sealed class SignUpToMarathonCommandValidator : AbstractValidator<SignUpToMarathonCommand>
    {
        public SignUpToMarathonCommandValidator()
        {
            RuleFor(x => x.RunnerId)
                .NotEmpty();
            RuleFor(x => x.RaceKitOptionId)
                .NotEmpty();
            RuleFor(x => x.CharityId)
                .NotEmpty();
            RuleFor(x => x.EventTypeIds)
                .NotEmpty()
                .Must(x => x.Any());
            RuleFor(x => x.SponsorshipTarget)
                .NotEmpty()
                .GreaterThan(default(decimal));
        }
    }
}
