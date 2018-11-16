using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Domain.Entities;
using Marathon.Application.Repositories;
using Marathon.Application.Users.Exceptions;
using Marathon.Application.Users.Queries;
using Marathon.Application.Users.Queries.GetUserType;
using Marathon.Application.Users.Queries.IsUserExists;

namespace Marathon.Application.Users.Commands.SignUp
{
    /// <summary>
    /// Handles <see cref="SignUpCommand"/>
    /// </summary>
    public sealed class SignUpCommandHandler : IRequestHandler<SignUpCommand, Unit>
    {
        private readonly IRepository<Runner> _runnerRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRequestHandler<IsUserExistsQuery, bool> _userChecker;
        private readonly IRequestHandler<GetUserTypeQuery, long> _userTypeFinder;

        public SignUpCommandHandler(IRepository<Runner> runnerRepository, 
            IRepository<User> userRepository,
            IRequestHandler<IsUserExistsQuery, bool> userChecker, 
            IRequestHandler<GetUserTypeQuery, long> userTypeFinder)
        {
            _runnerRepository = runnerRepository;
            _userRepository = userRepository;
            _userChecker = userChecker;
            _userTypeFinder = userTypeFinder;
        }

        public async Task<Unit> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            await CheckExistUser(request.Email, cancellationToken);

            long userId = await CreateNewUser(request, cancellationToken);
            
            await CreateNewRunner(request, userId, cancellationToken);
            
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

        private async Task<long> GetRunnerUserType(CancellationToken cancellationToken)
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

            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync(cancellationToken);

            return user.Id;
        }

        /// <summary>
        /// Converts <see cref="SignUpCommand"/> DTO to <see cref="Runner"/> entity and save it to runner repository
        /// </summary>
        /// <param name="request">Command's request DTO</param>
        /// <param name="userId">ID of new user</param>
        private async Task CreateNewRunner(SignUpCommand request, long userId, CancellationToken cancellationToken)
        {
            var runner = RunnerProjection(request, userId);

            _runnerRepository.Add(runner);
            await _runnerRepository.SaveChangesAsync(cancellationToken);
        }

        #endregion
    }
}
