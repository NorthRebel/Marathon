using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Domain.Entities;
using Marathon.Application.Repositories;
using Marathon.Application.Users.Exceptions;

namespace Marathon.Application.Users.Queries.GetUserType
{
    /// <summary>
    /// Handles <see cref="GetUserTypeQuery"/>
    /// </summary>
    public sealed class GetUserTypeQueryHandler : IRequestHandler<GetUserTypeQuery, long>
    {
        private readonly IReadOnlyRepository<UserType> _userTypeRepository;

        public GetUserTypeQueryHandler(IReadOnlyRepository<UserType> userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        public async Task<long> Handle(GetUserTypeQuery request, CancellationToken cancellationToken)
        {
            UserType userType = await _userTypeRepository.GetAsync(ut => ut.SingleOrDefault(u => u.Name == request.Name), cancellationToken);

            if (userType == null)
                throw new UserTypeNotExistsException(request.Name);

            return userType.Id;
        }
    }
}
