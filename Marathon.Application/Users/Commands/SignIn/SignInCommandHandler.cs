using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Application.Repositories;
using Marathon.Domain.Entities;
using MediatR;

namespace Marathon.Application.Users.Commands.SignIn
{
    public sealed class SignInCommandHandler : IRequestHandler<SignInCommand, User>
    {
        private readonly IReadOnlyRepository<User> _userRepository;

        public SignInCommandHandler(IReadOnlyRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(users =>
                users.SingleOrDefault(u => u.Email == request.Email && u.Password == request.Password), cancellationToken);

            return user;
        }
    }
}
