using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Application.Repositories;

namespace Marathon.Application.Sponsorship.Commands.SponsorshipRunner
{
    using Models;
    using Domain.Entities;

    /// <summary>
    /// Handles <see cref="SponsorshipRunnerCommand"/>
    /// </summary>
    public sealed class SponsorshipRunnerCommandHandler : IRequestHandler<SponsorshipRunnerCommand, Unit>
    {
        private readonly IRepository<Sponsorship> _sponsorshipRepository;

        public SponsorshipRunnerCommandHandler(IRepository<Sponsorship> sponsorshipRepository)
        {
            _sponsorshipRepository = sponsorshipRepository;
        }

        public async Task<Unit> Handle(SponsorshipRunnerCommand request, CancellationToken cancellationToken)
        {
            await SponsorshipRunner(request, cancellationToken);

            return Unit.Value;
        }

        #region Command handler helpers

        private Task<bool> TakePayment(CardCredentialsViewModel cardCredentials)
        {
            // TODO: Implement payment to bank organization
            return null;
        }

        /// <summary>
        /// Converts <see cref="SponsorshipRunnerCommand"/> DTO to <see cref="Sponsorship"/> entity and save it to sign up repository
        /// </summary>
        private async Task<long> SponsorshipRunner(SponsorshipRunnerCommand request, CancellationToken cancellationToken)
        {
            Sponsorship runnerSponsorship = SponsorshipProjection(request);

            _sponsorshipRepository.Add(runnerSponsorship);
            await _sponsorshipRepository.SaveChangesAsync(cancellationToken);

            return runnerSponsorship.Id;
        }

        /// <summary>
        /// Converts <see cref="SponsorshipRunnerCommand"/> DTO to <see cref="Sponsorship"/> entity
        /// </summary>
        private Sponsorship SponsorshipProjection(SponsorshipRunnerCommand request)
        {
            return new Sponsorship
            {
                Name = request.SponsorName,
                RegistrationId = request.RunnerMarathonSignUpId,
                Ammount = request.Amount
            };
        }

        #endregion
    }
}
