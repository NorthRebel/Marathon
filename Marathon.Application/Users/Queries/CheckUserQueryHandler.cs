using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Application.Repositories;
using Marathon.Domain.Entities;
using MediatR;

namespace Marathon.Application.Users.Queries
{
    /// <summary>
    /// Handles <see cref="CheckUserQuery"/>
    /// </summary>
    public sealed class CheckUserQueryHandler : IRequestHandler<CheckUserQuery, bool>
    {
        private readonly IReadOnlyRepository<User> _userRepository;

        public CheckUserQueryHandler(IReadOnlyRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(CheckUserQuery request, CancellationToken cancellationToken)
        {
            var userExists =
                await _userRepository.GetAsync(users => users.SingleOrDefault(u => u.Email == request.Email), cancellationToken);

            return userExists != null;
        }
    }
}
