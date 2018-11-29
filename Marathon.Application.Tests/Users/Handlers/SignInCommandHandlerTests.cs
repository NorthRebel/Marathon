using Xunit;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Domain.Entities;
using Marathon.Application.Tests.Extensions;
using Marathon.Application.Tests.Infrastructure;
using Marathon.Application.Users.Commands.SignIn;

namespace Marathon.Application.Tests.Users.Handlers
{
    /// <summary>
    /// Unit test module for <see cref="SignInCommandHandler"/>
    /// </summary>
    public class SignInCommandHandlerTests : IClassFixture<UnitOfWorkFixture>
    {
        private readonly UnitOfWorkFixture _unitOfWork;
        private readonly SignInCommandHandler _commandHandler;

        public SignInCommandHandlerTests(UnitOfWorkFixture unitOfWorkFixture)
        {
            _unitOfWork = unitOfWorkFixture;
            _commandHandler = new SignInCommandHandler(_unitOfWork.ContextFactory);
        }

        [Theory]
        [JsonFileData(@"Users\Data\UserData.json", "LoginData")]
        public async Task ReturnsUserById(SignInCommand request, User expected)
        {
            // Arrange
            User user = null;

            // Act

            _unitOfWork.Context.Users.Add(expected);
            await _unitOfWork.Context.CommitAsync(CancellationToken.None);

            user = await _commandHandler.Handle(request, CancellationToken.None);

            // Assert

            // Check right credentials 
            Assert.NotNull(user);

            // Verify user id
            Assert.Equal(expected.Id, user.Id);
        }
    }
}
