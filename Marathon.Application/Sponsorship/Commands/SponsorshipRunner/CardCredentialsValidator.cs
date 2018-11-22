using FluentValidation;
using Marathon.Application.Sponsorship.Commands.SponsorshipRunner.Models;

namespace Marathon.Application.Sponsorship.Commands.SponsorshipRunner
{
    /// <summary>
    /// Rules for arguments of <see cref="CardCredentialsViewModel"/> to right complete them
    /// </summary>
    public sealed class CardCredentialsValidator : AbstractValidator<CardCredentialsViewModel>
    {
        public CardCredentialsValidator()
        {
            RuleFor(x => x.Number)
                .NotEmpty();
            RuleFor(x => x.CVC)
                .NotEmpty();
            RuleFor(x => x.Holder)
                .NotEmpty();
            RuleFor(x => x.MonthValidity)
                .NotEmpty();
            RuleFor(x => x.YearValidity)
                .NotEmpty();
        }
    }
}
