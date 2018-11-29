using Xunit;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;
using Marathon.Domain.Entities;
using Marathon.Application.Tests.Extensions;
using Marathon.Application.Tests.Infrastructure;
using Marathon.Application.Users.Commands.SignIn;

namespace Marathon.Application.Tests.Users.Handlers
{
    /// <summary>
    /// Unit test module for <see cref="SignInCommandHandler"/>
    /// </summary>
    public class SignInCommandHandlerTests : IClassFixture<DbContextFixture>
    {
        private readonly SignInCommandHandler _commandHandler;

        private readonly IUnitOfWork _uow;

        public SignInCommandHandlerTests(DbContextFixture contextFixture)
        {
            IUnitOfWorkFactory uowFactory = new FixtureUoWFactory(contextFixture);
            _commandHandler = new SignInCommandHandler(uowFactory);

            _uow = uowFactory.Create();
        }

        [Theory]
        [JsonFileData(@"Users\Data\UserData.json", "LoginData")]
        public async Task ReturnsUserById(SignInCommand request, User expected)
        {
            // Arrange
            User user = null;

            // Act

            _uow.Users.Add(expected);
            await _uow.CommitAsync(CancellationToken.None);

            user = await _commandHandler.Handle(request, CancellationToken.None);

            // Assert

            // Check right credentials 
            Assert.NotNull(user);

            // Verify user id
            Assert.Equal(expected.Id, user.Id);
        }
    }
}
