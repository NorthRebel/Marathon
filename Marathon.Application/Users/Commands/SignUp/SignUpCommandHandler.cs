using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;
using Marathon.Domain.Entities;
using Marathon.Application.Users.Exceptions;
using Marathon.Application.Users.Queries.GetUserType;
using Marathon.Application.Users.Queries.IsUserExists;

namespace Marathon.Application.Users.Commands.SignUp
{
    /// <summary>
    /// Handles <see cref="SignUpCommand"/>
    /// </summary>
    public sealed class SignUpCommandHandler : IRequestHandler<SignUpCommand, Unit>
    {
        private readonly IUnitOfWork _dbContext;

        private readonly IRequestHandler<IsUserExistsQuery, bool> _userChecker;
        private readonly IRequestHandler<GetUserTypeQuery, char> _userTypeFinder;

        public SignUpCommandHandler(IUnitOfWorkFactory uowFactory,
            IRequestHandler<IsUserExistsQuery, bool> userChecker, 
            IRequestHandler<GetUserTypeQuery, char> userTypeFinder)
        {
            _dbContext = uowFactory.Create();

            _userChecker = userChecker;
            _userTypeFinder = userTypeFinder;
        }

        public async Task<Unit> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            await CheckExistUser(request.Email, cancellationToken);

            long userId = await CreateNewUser(request, cancellationToken);
            
            CreateNewRunner(request, userId);

            await _dbContext.CommitAsync(cancellationToken);
            
            return Unit.Value;
        }

        #region Command handler helpers

        private async Task CheckExistUser(string email, CancellationToken cancellationToken)
        {
            if (await _userChecker.Handle(new IsUserExistsQuery { Email = email }, cancellationToken))
                throw new UserAlreadyExistsException(email);
        }

        /// <summary>
        /// Converts <see cref="SignUpCommand"/> DTO to <see cref="User"/> entity
        /// </summary>
        private async Task<User> UserProjection(SignUpCommand request, CancellationToken cancellationToken)
        {
            return new User
            {
                Email = request.Email,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserTypeId = await GetRunnerUserType(cancellationToken)
            };
        }

        private async Task<char> GetRunnerUserType(CancellationToken cancellationToken)
        {
            return await _userTypeFinder.Handle(new GetUserTypeQuery(Domain.Enumerations.UserType.Runner.ToString()),
                cancellationToken);
        }

        /// <summary>
        /// Converts <see cref="SignUpCommand"/> DTO to <see cref="Runner"/> entity
        /// </summary>
        private Runner RunnerProjection(SignUpCommand request, long userId)
        {
            return new Runner
            {
                UserId = userId,
                Photo = request.Photo,
                CountryId = request.CountryId,
                DateOfBirth = request.DateOfBirth,
                GenderId = request.GenderId
            };
        }

        /// <summary>
        /// Converts <see cref="SignUpCommand"/> DTO to <see cref="User"/> entity and save it to user repository
        /// </summary>
        /// <param name="request">Command's request DTO</param> 
        /// <returns>ID of new user</returns>
        private async Task<long> CreateNewUser(SignUpCommand request, CancellationToken cancellationToken)
        {
            var user = await UserProjection(request, cancellationToken);

            _dbContext.Users.Add(user);

            return user.Id;
        }

        /// <summary>
        /// Converts <see cref="SignUpCommand"/> DTO to <see cref="Runner"/> entity and save it to runner repository
        /// </summary>
        /// <param name="request">Command's request DTO</param>
        /// <param name="userId">ID of new user</param>
        private void CreateNewRunner(SignUpCommand request, long userId)
        {
            var runner = RunnerProjection(request, userId);

            _dbContext.Runners.Add(runner);
        }

        #endregion
    }
}
