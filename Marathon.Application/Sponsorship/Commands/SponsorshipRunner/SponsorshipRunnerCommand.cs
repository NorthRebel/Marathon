using MediatR;
using Marathon.Domain.Entities;
using Marathon.Application.Sponsorship.Commands.SponsorshipRunner.Models;

namespace Marathon.Application.Sponsorship.Commands.SponsorshipRunner
{
    /// <summary>
    /// Do sponsorship for <see cref="Runner"/> which signed up to <see cref="MarathonSignUp"/>
    /// </summary>
    public sealed class SponsorshipRunnerCommand : IRequest
    {
        public string SponsorName { get; set; }
        public long RunnerMarathonSignUpId { get; set; }
        public decimal Amount { get; set; }
        public CardCredentialsViewModel CardCredentials { get; set; }
    }
}
