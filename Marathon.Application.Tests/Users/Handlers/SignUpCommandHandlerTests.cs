using Xunit;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;
using Marathon.Domain.Entities;
using Marathon.DAL.Repositories;
using System.Collections.Generic;
using Marathon.Application.Tests.Extensions;
using Marathon.Application.Tests.Infrastructure;
using Marathon.Application.Users.Exceptions;
using Marathon.Application.Users.Commands.SignUp;
using Marathon.Application.Users.Queries.GetUserType;
using Marathon.Application.Users.Queries.IsUserExists;
using UserTypeEnum = Marathon.Domain.Enumerations.UserType;

namespace Marathon.Application.Tests.Users.Handlers
{
    /// <summary>
    /// Unit test module for <see cref="SignUpCommandHandler"/>
    /// </summary>
    [Collection("Database collection")]
    public class SignUpCommandHandlerTests
    {
        private readonly SignUpCommandHandler _signUpCommandHandler;

        private readonly IUnitOfWork _uow;

        public SignUpCommandHandlerTests(DbContextFixture contextFixture)
        {
            IUnitOfWorkFactory uowFactory = new FixtureUoWFactory(contextFixture);

            _uow = uowFactory.Create();

            _uow.Initialize(async uow =>
            {
                ((IRepository<UserType>)uow.UserTypes).ImportFromCollection(CreateUserTypes());

                uow.Users.ImportFromJson(@"Users\Data\RunnerUsers.json");
                await uow.CommitAsync(CancellationToken.None);

                IEnumerable<User> users = await uow.Users.GetAllAsync();

                uow.Runners.ImportFromCollection(users.Select(u => new Runner { UserId = u.Id }));
                await uow.CommitAsync(CancellationToken.None);
            });

            #region Setup handlers

            var isUserExistsQueryHandler = new IsUserExistsQueryHandler(uowFactory);

            var getUserTypeQueryHandler = new GetUserTypeQueryHandler(uowFactory);

            _signUpCommandHandler = new SignUpCommandHandler(uowFactory, isUserExistsQueryHandler, getUserTypeQueryHandler);

            #endregion
        }

        //private async Task SeedData()
        //{
        //    ((IRepository<UserType>)_context.UserTypes).ImportFromCollection(CreateUserTypes());

        //    _context.Users.ImportFromJson(@"Users\Data\RunnerUsers.json");
        //    await _context.CommitAsync(CancellationToken.None);

        //    IEnumerable<User> users = await _context.Users.GetAllAsync();

        //    _context.Runners.ImportFromCollection(users.Select(u => new Runner { UserId = u.Id }));
        //    await _context.CommitAsync(CancellationToken.None);
        //}

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
        public async Task RunnerMustGetHisUserType()
        {
            // Arrange

            var request = new SignUpCommand { Email = "newRunner@gmail.com" };

            // Act

            await _signUpCommandHandler.Handle(request, CancellationToken.None);

            User createdUser = await _uow.Users.GetSingleAsync(u => u.Email == request.Email);
            long userTypeId = createdUser.UserTypeId;

            // Assert
            Assert.Equal(UserTypeEnum.Runner.Id, userTypeId);
        }

        [Theory]
        [JsonFileData(@"Users\Data\RunnersRequests.json", "RunnerMustGetIdAfterSignUp")]
        public async Task RunnerMustGetIdAfterSignUp(SignUpCommand request)
        {
            // Act

            await _signUpCommandHandler.Handle(request, CancellationToken.None);

            User createdUser = await _uow.Users.GetSingleAsync(u => u.Email == request.Email);
            Runner createdRunner = await _uow.Runners.GetSingleAsync(r => r.UserId == createdUser.Id);

            // Assert

            Assert.NotEqual(default(long), createdUser.Id);
            Assert.NotEqual(default(long), createdRunner.Id);
        }

        [Theory]
        [JsonFileData(@"Users\Data\RunnersRequests.json", "EmailMustBeUnique")]
        public async Task EmailMustBeUnique(SignUpCommand request)
        {
            // Act-Assert

            await Assert.ThrowsAsync<UserAlreadyExistsException>(async () =>
                await _signUpCommandHandler.Handle(request, CancellationToken.None));
        }
    }
}
