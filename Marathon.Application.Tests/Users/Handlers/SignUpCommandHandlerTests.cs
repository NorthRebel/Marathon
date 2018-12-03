using Xunit;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Domain.Entities;
using Marathon.DAL.Repositories;
using System.Collections.Generic;
using Marathon.Tests.DAL.Extensions;
using Marathon.Tests.DAL.Infrastructure;
using Marathon.Application.Tests.Extensions;
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
    public class SignUpCommandHandlerTests : IClassFixture<UnitOfWorkFixture>
    {
        private readonly UnitOfWorkFixture _unitOfWork;
        private readonly SignUpCommandHandler _signUpCommandHandler;

        public SignUpCommandHandlerTests(UnitOfWorkFixture unitOfWorkFixture)
        {
            _unitOfWork = unitOfWorkFixture;

            _unitOfWork.Context.Initialize(async uow =>
            {
                uow.Users.ImportFromJson(@"Users\Data\RunnerUsers.json");
                await uow.CommitAsync(CancellationToken.None);

                IEnumerable<User> users = await uow.Users.GetAllAsync();

                uow.Runners.ImportFromCollection(users.Select(u => new Runner { UserId = u.Id }));
                await uow.CommitAsync(CancellationToken.None);
            });

            #region Setup handlers

            var isUserExistsQueryHandler = new IsUserExistsQueryHandler(_unitOfWork.ContextFactory);

            var getUserTypeQueryHandler = new GetUserTypeQueryHandler(_unitOfWork.ContextFactory);

            _signUpCommandHandler = new SignUpCommandHandler(_unitOfWork.ContextFactory, isUserExistsQueryHandler, getUserTypeQueryHandler);

            #endregion
        }

        [Fact]
        public async Task RunnerMustGetHisUserType()
        {
            // Arrange

            var request = new SignUpCommand { Email = "newRunner@gmail.com" };

            // Act

            await _signUpCommandHandler.Handle(request, CancellationToken.None);

            User createdUser = await _unitOfWork.Context.Users.GetSingleAsync(u => u.Email == request.Email);
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

            User createdUser = await _unitOfWork.Context.Users.GetSingleAsync(u => u.Email == request.Email);
            Runner createdRunner = await _unitOfWork.Context.Runners.GetSingleAsync(r => r.UserId == createdUser.Id);

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
