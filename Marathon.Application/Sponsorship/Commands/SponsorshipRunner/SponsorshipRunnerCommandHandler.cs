using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;

namespace Marathon.Application.Sponsorship.Commands.SponsorshipRunner
{
    using Models;
    using Domain.Entities;

    /// <summary>
    /// Handles <see cref="SponsorshipRunnerCommand"/>
    /// </summary>
    public sealed class SponsorshipRunnerCommandHandler : IRequestHandler<SponsorshipRunnerCommand, Unit>
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public SponsorshipRunnerCommandHandler(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
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

            using (IUnitOfWork context = _uowFactory.Create())
            {
                context.Sponsorships.Add(runnerSponsorship);
                await context.CommitAsync(cancellationToken);
            }

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
