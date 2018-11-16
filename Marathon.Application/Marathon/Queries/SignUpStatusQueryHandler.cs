using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Domain.Entities;
using Marathon.Application.Repositories;
using Marathon.Application.Users.Exceptions;

namespace Marathon.Application.Marathon.Queries
{
    /// <summary>
    /// Handles <see cref="SignUpStatusQuery"/>
    /// </summary>
    public sealed class SignUpStatusQueryHandler : IRequestHandler<SignUpStatusQuery, long>
    {
        private readonly IReadOnlyRepository<SignUpStatus> _signUpStatusRepository;

        public SignUpStatusQueryHandler(IReadOnlyRepository<SignUpStatus> signUpStatusRepository)
        {
            _signUpStatusRepository = signUpStatusRepository;
        }

        public async Task<long> Handle(SignUpStatusQuery request, CancellationToken cancellationToken)
        {
            SignUpStatus signUpStatus = await _signUpStatusRepository.GetAsync(status => status.SingleOrDefault(s => s.Name == request.Name),
                cancellationToken);

            if (signUpStatus == null)
                throw new SignUpStatusNotExistsException(request.Name);

            return signUpStatus.Id;
        }
    }
}