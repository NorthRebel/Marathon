using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Application.Repositories;
using Marathon.Application.Tests.Extensions;
using Marathon.Application.Users.Commands.SignIn;
using Marathon.Domain.Entities;
using Moq;
using Xunit;

namespace Marathon.Application.Tests.Users.Commands
{
    /// <summary>
    /// Unit test module for <see cref="SignInCommand"/>
    /// </summary>
    public sealed class SignInCommandTests
    {
        private readonly SignInCommandHandler _commandHandler;
        private readonly List<User> _users;

        private readonly Mock<IReadOnlyRepository<User>> _userReadRepository;
        private readonly CancellationToken _cancellationToken;

        public SignInCommandTests()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            _cancellationToken = cancelTokenSource.Token;

            _users = new List<User>();
            _userReadRepository = new Mock<IReadOnlyRepository<User>>();

            _commandHandler = new SignInCommandHandler(_userReadRepository.Object);
        }

        [Theory]
        [JsonFileData("UserData.json", "LoginData")]
        public async Task ReturnsUserById(SignInCommand request, User expected)
        {
            // Arrange
            User user = null;

            _userReadRepository
                .Setup(ur => ur.GetAsync(It.IsAny<Func<IQueryable<User>, User>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expected)
                .Callback((Func<IQueryable<User>, User> query, CancellationToken token) =>
                {
                    _users.Add(expected);
                    user = query(_users.AsQueryable());
                });

            // Act
            await _commandHandler.Handle(request, _cancellationToken);

            // Assert

            // Operation is successful
            Assert.False(_cancellationToken.IsCancellationRequested);

            // Check right credentials 
            Assert.NotNull(user);

            // Verify user id
            Assert.Equal(expected.Id, user.Id);

            // Check repository
            _userReadRepository.Verify(x => x.GetAsync(It.IsAny<Func<IQueryable<User>, User>>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
