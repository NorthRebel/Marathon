using Xunit;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.Repositories;
using Marathon.Application.Tests.Infrastructure;
using Marathon.Application.Sponsorship.Commands.SponsorshipRunner;

namespace Marathon.Application.Tests.Sponsorship.Handlers
{
    using Domain.Entities;

    /// <summary>
    /// Unit test module for <see cref="SponsorshipRunnerCommandHandler"/>
    /// </summary>
    public class SponsorshipRunnerCommandHandlerTests : IClassFixture<UnitOfWorkFixture>
    {
        private readonly UnitOfWorkFixture _unitOfWork;
        private readonly SponsorshipRunnerCommandHandler _sponsorshipRunnerCommandHandler;

        public SponsorshipRunnerCommandHandlerTests(UnitOfWorkFixture unitOfWorkFixture)
        {
            _unitOfWork = unitOfWorkFixture;
            _sponsorshipRunnerCommandHandler = new SponsorshipRunnerCommandHandler(_unitOfWork.ContextFactory);
        }

        [Fact]
        public async Task HandlerMustReturnIdAfterSponsorship()
        {
            // Arrange

            var request = new SponsorshipRunnerCommand
            {
                SponsorName = "Adam Frederic",
                Amount = 25600m,
                RunnerMarathonSignUpId = 10
            };

            // Act

            await _sponsorshipRunnerCommandHandler.Handle(request, CancellationToken.None);

            Sponsorship sponsorship = await _unitOfWork.Context.Sponsorships.GetSingleAsync(s => s.Name == request.SponsorName);

            // Assert

            Assert.NotEqual(default(long), sponsorship.Id);
        }
    }
}
