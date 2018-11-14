using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Application.Exceptions;
using Moq;
using Xunit;
using Marathon.Domain.Entities;
using Marathon.Application.Repositories;
using Marathon.Application.Users.Queries;
using Marathon.Application.Tests.Extensions;
using Marathon.Application.Tests.Infrastructure;
using Marathon.Application.Users.Commands.SignUp;

namespace Marathon.Application.Tests.Users.Handlers
{
    /// <summary>
    /// Unit test module for <see cref="SignUpCommandHandler"/>
    /// </summary>
    public class SignUpCommandHandlerTests
    {
        private readonly SignUpCommandHandler _signUpCommandHandler;
        private readonly CheckUserQueryHandler _checkUserQueryHandler;

        private readonly Mock<IRepository<Runner>> _runnerRepository;
        private readonly Mock<IRepository<User>> _userWriteRepository;
        private readonly Mock<IReadOnlyRepository<User>> _userReadRepository;

        private readonly CancellationToken _cancellationToken;

        public List<Runner> Runners { get; }
        public List<User> Users { get; }

        public SignUpCommandHandlerTests()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            _cancellationToken = cancelTokenSource.Token;

            #region Initialize collections

            Users = new StorageFactory<User>()
                .FromJson("RunnerUsers.json")
                .Create();

            Runners = new StorageFactory<Runner>()
                .FromCollection(CreateRunnersOfUsers(Users))
                .Create();

            #endregion

            _runnerRepository = new Mock<IRepository<Runner>>();
            _userWriteRepository = new Mock<IRepository<User>>();
            _userReadRepository = new Mock<IReadOnlyRepository<User>>();

            #region Setup mocks

            // Add id for new runner
            _userWriteRepository.Setup(u => u.Add(It.IsAny<User>()))
                .Callback((User newUser) =>
                {
                    newUser.Id = Users.Max(u => u.Id) + 1;
                    Users.Add(newUser);
                });

            // Add id for new runner
            _runnerRepository.Setup(r => r.Add(It.IsAny<Runner>()))
                .Callback((Runner newRunner) =>
                {
                    newRunner.Id = newRunner.UserId;
                    Runners.Add(newRunner);
                });

            // Check user for exists
            _userReadRepository.Setup(u =>
                    u.GetAsync(It.IsAny<Func<IQueryable<User>, User>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Func<IQueryable<User>, User> users, CancellationToken cancellationToken) =>
                    users.Invoke(Users.AsQueryable()));

            #endregion

            _checkUserQueryHandler = new CheckUserQueryHandler(_userReadRepository.Object);
            _signUpCommandHandler =
                new SignUpCommandHandler(_runnerRepository.Object, _userWriteRepository.Object, _checkUserQueryHandler);
        }

        private IEnumerable<Runner> CreateRunnersOfUsers(IEnumerable<User> users)
        {
            var runners = new List<Runner>();
            int i = 0;
            foreach (User user in users)
            {
                runners.Add(new Runner
                {
                    Id = i++,
                    User = user
                });
            }

            return runners;
        }

        [Fact]
        public async Task HandlerMustCallRepositories()
        {
            // Arrange

            var request = new SignUpCommand { Email = "mymail@gmail.com"};

            // Act

            await _signUpCommandHandler.Handle(request, _cancellationToken);

            // Assert

            _userWriteRepository.Verify(u => u.Add(It.IsAny<User>()), Times.Once);
            _runnerRepository.Verify(u => u.Add(It.IsAny<Runner>()), Times.Once);
            _userReadRepository.Verify(
                x => x.GetAsync(It.IsAny<Func<IQueryable<User>, User>>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Theory]
        [JsonFileData("RunnersRequests.json", "RunnerMustGetIdAfterSignUp")]
        public async Task RunnerMustGetIdAfterSignUp(SignUpCommand request)
        {
            // Act

            await _signUpCommandHandler.Handle(request, _cancellationToken);

            // Assert

            long id = Users.Find(u => u.Email == request.Email).Id;
            Assert.NotEqual(default(long), id);
        }

        [Theory]
        [JsonFileData("RunnersRequests.json", "EmailMustBeUnique")]
        public async Task EmailMustBeUnique(SignUpCommand request)
        {
            // Act-Assert

            await Assert.ThrowsAsync<UserAlreadyExistsException>(async () =>
                await _signUpCommandHandler.Handle(request, _cancellationToken));            
        }
    }
}
