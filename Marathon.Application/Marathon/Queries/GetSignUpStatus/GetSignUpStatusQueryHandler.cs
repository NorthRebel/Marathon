using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Domain.Entities;
using Marathon.Application.Repositories;
using Marathon.Application.Users.Exceptions;

namespace Marathon.Application.Marathon.Queries.GetSignUpStatus
{
    /// <summary>
    /// Handles <see cref="GetSignUpStatusQuery"/>
    /// </summary>
    public sealed class GetSignUpStatusQueryHandler : IRequestHandler<GetSignUpStatusQuery, long>
    {
        private readonly IReadOnlyRepository<SignUpStatus> _signUpStatusRepository;

        public GetSignUpStatusQueryHandler(IReadOnlyRepository<SignUpStatus> signUpStatusRepository)
        {
            _signUpStatusRepository = signUpStatusRepository;
        }

        public async Task<long> Handle(GetSignUpStatusQuery request, CancellationToken cancellationToken)
        {
            SignUpStatus signUpStatus = await _signUpStatusRepository.GetAsync(status => status.SingleOrDefault(s => s.Name == request.Name),
                cancellationToken);

            if (signUpStatus == null)
                throw new SignUpStatusNotExistsException(request.Name);

            return signUpStatus.Id;
        }
    }
}