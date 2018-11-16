using Moq;
using Xunit;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Domain.Entities;
using System.Collections.Generic;
using Marathon.Application.Tests.Extensions;
using Marathon.Application.Users.Exceptions;
using Marathon.Application.Users.Commands.SignUp;
using Marathon.Application.Users.Queries.GetUserType;
using Marathon.Application.Users.Queries.IsUserExists;
using UserTypeEnum = Marathon.Domain.Enumerations.UserType;
using Marathon.Application.Tests.Infrastructure.Repositories;

namespace Marathon.Application.Tests.Users.Handlers
{
    /// <summary>
    /// Unit test module for <see cref="SignUpCommandHandler"/>
    /// </summary>
    public class SignUpCommandHandlerTests
    {
        private readonly SignUpCommandHandler _signUpCommandHandler;
        private readonly IsUserExistsQueryHandler _isUserExistsQueryHandler;
        private readonly GetUserTypeQueryHandler _getUserTypeQueryHandler;

        private readonly RepositoryMock<Runner> _runnerRepository;
        private readonly RepositoryMock<User> _userWriteRepository;
        private readonly ReadOnlyRepositoryMock<User> _userReadRepository;
        private readonly ReadOnlyRepositoryMock<UserType> _userTypeRepository;

        private readonly CancellationToken _cancellationToken;

        public SignUpCommandHandlerTests()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            _cancellationToken = cancelTokenSource.Token;

            #region Mock repositories

            _userReadRepository = (ReadOnlyRepositoryMock<User>)new ReadOnlyRepositoryMock<User>()
                .FromJson(@"Users\RunnerUsers.json");

            _runnerRepository = (RepositoryMock<Runner>)new RepositoryMock<Runner>()
                .FromCollection(CreateRunnersOfUsers(_userReadRepository.Items));

            _userWriteRepository = new RepositoryMock<User>();

            _userTypeRepository = (ReadOnlyRepositoryMock<UserType>)new ReadOnlyRepositoryMock<UserType>()
                .FromCollection(CreateUserTypes());

            #endregion

            #region Setup handlers

            _isUserExistsQueryHandler = new IsUserExistsQueryHandler(_userReadRepository.Object);

            _getUserTypeQueryHandler = new GetUserTypeQueryHandler(_userTypeRepository.Object);

            _signUpCommandHandler =
                new SignUpCommandHandler(_runnerRepository.Object,
                                         _userWriteRepository.Object,
                                         _isUserExistsQueryHandler,
                                         _getUserTypeQueryHandler);
            #endregion
        }

        /// <summary>
        /// Signs up users as runners to complete some tests
        /// </summary>
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

        /// <summary>
        /// Converts <see cref="Domain.Enumerations.UserType"/> linked enumeration to <see cref="IEnumerable{UserType}"/>
        /// </summary>
        /// <returns></returns>
        private IEnumerable<UserType> CreateUserTypes()
        {
            foreach (var userType in UserTypeEnum.GetAll<UserTypeEnum>())
            {
                yield return new UserType
                {
                    Id = userType.Id,
                    Name = userType.Name
                };
            }
        }

        [Fact]
        public async Task HandlerMustCallRepositories()
        {
            // Arrange

            var request = new SignUpCommand { Email = "mymail@gmail.com" };

            // Act

            await _signUpCommandHandler.Handle(request, _cancellationToken);

            // Assert

            _userWriteRepository.Verify(u => u.Add(It.IsAny<User>()), Times.Once);
            _runnerRepository.Verify(u => u.Add(It.IsAny<Runner>()), Times.Once);
            _userReadRepository.Verify(
                x => x.GetAsync(It.IsAny<Func<IQueryable<User>, User>>(), It.IsAny<CancellationToken>()), Times.Once);
            _userTypeRepository.Verify(
                x => x.GetAsync(It.IsAny<Func<IQueryable<UserType>, UserType>>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task RunnerMustGetHisUserType()
        {
            // Arrange

            var request = new SignUpCommand { Email = "newRunner@gmail.com" };

            // Act

            await _signUpCommandHandler.Handle(request, _cancellationToken);

            // Assert

            long userTypeId = _userWriteRepository.Items.Find(u => u.Email == request.Email).UserTypeId;
            Assert.Equal(UserTypeEnum.Runner.Id, userTypeId);
        }

        [Theory]
        [JsonFileData(@"Users\RunnersRequests.json", "RunnerMustGetIdAfterSignUp")]
        public async Task RunnerMustGetIdAfterSignUp(SignUpCommand request)
        {
            // Act

            await _signUpCommandHandler.Handle(request, _cancellationToken);

            // Assert

            long id = _userWriteRepository.Items.Find(u => u.Email == request.Email).Id;
            Assert.NotEqual(default(long), id);
        }

        [Theory]
        [JsonFileData(@"Users\RunnersRequests.json", "EmailMustBeUnique")]
        public async Task EmailMustBeUnique(SignUpCommand request)
        {
            // Act-Assert

            await Assert.ThrowsAsync<UserAlreadyExistsException>(async () =>
                await _signUpCommandHandler.Handle(request, _cancellationToken));
        }
    }
}
