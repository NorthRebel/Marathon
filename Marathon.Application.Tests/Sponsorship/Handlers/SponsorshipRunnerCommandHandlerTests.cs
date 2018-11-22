using Moq;
using Xunit;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Application.Tests.Infrastructure.Repositories;
using Marathon.Application.Sponsorship.Commands.SponsorshipRunner;

namespace Marathon.Application.Tests.Sponsorship.Handlers
{
    using Domain.Entities;

    /// <summary>
    /// Unit test module for <see cref="SponsorshipRunnerCommandHandler"/>
    /// </summary>
    public class SponsorshipRunnerCommandHandlerTests
    {
        private readonly SponsorshipRunnerCommandHandler _sponsorshipRunnerCommandHandler;

        private readonly RepositoryMock<Sponsorship> _sponsorshipRepository;

        private readonly CancellationToken _cancellationToken;

        public SponsorshipRunnerCommandHandlerTests()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            _cancellationToken = cancelTokenSource.Token;

            _sponsorshipRepository = new RepositoryMock<Sponsorship>();

            _sponsorshipRunnerCommandHandler = new SponsorshipRunnerCommandHandler(_sponsorshipRepository.Object);
        }

        [Fact]
        public async Task HandlerMustCallRepositories()
        {
            // Arrange

            var request = new SponsorshipRunnerCommand
            {
                SponsorName = "Adam Frederic",
                Amount = 25600m,
                RunnerMarathonSignUpId = 10
            };

            // Act

            await _sponsorshipRunnerCommandHandler.Handle(request, _cancellationToken);

            // Assert

            _sponsorshipRepository.Verify(s => s.Add(It.IsAny<Sponsorship>()), Times.Once);
            _sponsorshipRepository.Verify(s => s.SaveChangesAsync(_cancellationToken), Times.Once);
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

            await _sponsorshipRunnerCommandHandler.Handle(request, _cancellationToken);

            // Assert

            long id = _sponsorshipRepository.Items.Find(s => s.Name == request.SponsorName).Id;
            Assert.NotEqual(default(long), id);
        }
    }
}
