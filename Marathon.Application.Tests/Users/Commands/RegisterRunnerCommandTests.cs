using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Application.Exceptions;
using Marathon.Application.Repositories;
using Marathon.Application.Tests.Extensions;
using Marathon.Application.Tests.Infrastructure;
using Marathon.Application.Users.Commands.Register;
using Marathon.Application.Users.Queries;
using Marathon.Domain.Entities;
using Moq;
using Xunit;

namespace Marathon.Application.Tests.Users.Commands
{
    /// <summary>
    /// Unit test module for <see cref="RegisterRunnerCommand"/>
    /// </summary>
    public sealed class RegisterRunnerCommandTests
    {
        private readonly RegisterRunnerCommandHandler _registerRunnerCommand;
        private readonly CheckUserQueryHandler _checkUserQuery;

        private Mock<IRepository<Runner>> _runnerRepository;
        private Mock<IRepository<User>> _userWriteRepository;
        private Mock<IReadOnlyRepository<User>> _userReadRepository;

        private readonly CancellationToken _cancellationToken;

        public IEnumerable<Runner> Runners { get; }
        public IEnumerable<User> Users { get; }

        public RegisterRunnerCommandTests()
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


            _checkUserQuery = new CheckUserQueryHandler(_userReadRepository.Object);
            _registerRunnerCommand =
                new RegisterRunnerCommandHandler(_runnerRepository.Object, _userWriteRepository.Object, _checkUserQuery);

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

        [Theory]
        [JsonFileData("RunnersRequests.json", "EmailMustBeUnique")]
        public async Task EmailMustBeUnique(RegisterRunnerCommand request)
        {
            // Arrange
            _userReadRepository
                .Setup(ur => ur.GetAsync(It.IsAny<Func<IQueryable<User>, User>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(It.IsAny<User>())
                .Callback((Func<IQueryable<User>, User> query, CancellationToken token) => query(Users.AsQueryable()));

            // Assert

            await _registerRunnerCommand.Handle(request, _cancellationToken);

            // Check repository

            _userReadRepository.VerifyAll();

            await Assert.ThrowsAsync<UserAlreadyExistsException>(async () =>
                await _registerRunnerCommand.Handle(request, _cancellationToken));

            _userReadRepository.Verify(
                x => x.GetAsync(It.IsAny<Func<IQueryable<User>, User>>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        //[Theory]
        //public async Task RegisterRunner()
        //{
        //}
    }
}
