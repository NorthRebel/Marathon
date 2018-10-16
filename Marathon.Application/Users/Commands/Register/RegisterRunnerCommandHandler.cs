using System.Threading;
using System.Threading.Tasks;
using Marathon.Application.Exceptions;
using Marathon.Application.Repositories;
using Marathon.Application.Users.Queries;
using Marathon.Domain.Entities;
using MediatR;

namespace Marathon.Application.Users.Commands.Register
{
    /// <summary>
    /// Handles <see cref="RegisterRunnerCommand"/>
    /// </summary>
    public sealed class RegisterRunnerCommandHandler : IRequestHandler<RegisterRunnerCommand, Unit>
    {
        private readonly IRepository<Runner> _runnerRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRequestHandler<CheckUserQuery, bool> _userChecker;

        public RegisterRunnerCommandHandler(IRepository<Runner> runnerRepository, 
            IRepository<User> userRepository,
            IRequestHandler<CheckUserQuery, bool> userChecker)
        {
            _runnerRepository = runnerRepository;
            _userRepository = userRepository;
            _userChecker = userChecker;
        }

        public async Task<Unit> Handle(RegisterRunnerCommand request, CancellationToken cancellationToken)
        {
            if (await _userChecker.Handle(new CheckUserQuery { Email = request.Email}, cancellationToken))
                throw new UserAlreadyExistsException(request.Email);

            var user = new User
            {
                Email = request.Email,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                // TODO: How to get user type?
                //UserType = 
            };

            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync(cancellationToken);

            var runner = new Runner
            {
                UserId = user.Id,
                Photo = request.Photo,
                CountryId = request.CountryId,
                DateOfBirth = request.DateOfBirth,
                GenderId = request.GenderId
            };

            _runnerRepository.Add(runner);
            await _runnerRepository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
