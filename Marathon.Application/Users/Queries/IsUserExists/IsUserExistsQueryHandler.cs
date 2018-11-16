using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Domain.Entities;
using Marathon.Application.Repositories;

namespace Marathon.Application.Users.Queries.IsUserExists
{
    /// <summary>
    /// Handles <see cref="IsUserExistsQuery"/>
    /// </summary>
    public sealed class IsUserExistsQueryHandler : IRequestHandler<IsUserExistsQuery, bool>
    {
        private readonly IReadOnlyRepository<User> _userRepository;

        public IsUserExistsQueryHandler(IReadOnlyRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(IsUserExistsQuery request, CancellationToken cancellationToken)
        {
            var userExists =
                await _userRepository.GetAsync(users => users.SingleOrDefault(u => u.Email == request.Email), cancellationToken);

            return userExists != null;
        }
    }
}
