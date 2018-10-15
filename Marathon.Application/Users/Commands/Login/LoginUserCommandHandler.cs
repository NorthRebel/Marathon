using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Application.Repositories;
using Marathon.Domain.Entities;
using MediatR;

namespace Marathon.Application.Users.Commands.Login
{
    public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, User>
    {
        private readonly IReadOnlyRepository<User> _userRepository;

        public LoginUserCommandHandler(IReadOnlyRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(users =>
                users.SingleOrDefault(u => u.Email == request.Email && u.Password == request.Password), cancellationToken);

            return user;
        }
    }
}
