using Xunit;
using System.Threading;
using Marathon.Tests.DAL;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;
using Marathon.DAL.Repositories;
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

        private readonly IUnitOfWorkFactory _uowFactory;

        public SponsorshipRunnerCommandHandlerTests()
        {
            _uowFactory = new UnitOfWorkFactory(nameof(SponsorshipRunnerCommandHandlerTests));

            _sponsorshipRunnerCommandHandler = new SponsorshipRunnerCommandHandler(_uowFactory);
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

            IUnitOfWork context = _uowFactory.Create();

            Sponsorship sponsorship = await context.Sponsorships.GetSingleAsync(s => s.Name == request.SponsorName);

            // Assert

            Assert.NotEqual(default(long), sponsorship.Id);

            // Cleanup
            context.Dispose();
        }
    }
}
