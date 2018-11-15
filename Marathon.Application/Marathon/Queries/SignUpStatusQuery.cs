using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Domain.Entities;
using Marathon.Application.Exceptions;
using Marathon.Application.Repositories;

namespace Marathon.Application.Marathon.Queries
{
    /// <summary>
    /// Gets runner's marathon sign up status code by name
    /// </summary>
    public sealed class SignUpStatusQuery : IRequest<long>
    {
        public string Name { get; set; }

        public SignUpStatusQuery(string name)
        {
            Name = name;
        }
    }

    public sealed class SignUpStatusQueryHandler : IRequestHandler<SignUpStatusQuery, long>
    {
        private readonly IReadOnlyRepository<RegistrationStatus> _registrationStatusRepository;

        public SignUpStatusQueryHandler(IReadOnlyRepository<RegistrationStatus> registrationStatusRepository)
        {
            _registrationStatusRepository = registrationStatusRepository;
        }

        public async Task<long> Handle(SignUpStatusQuery request, CancellationToken cancellationToken)
        {
            RegistrationStatus regStatus = await _registrationStatusRepository.GetAsync(status => status.SingleOrDefault(s => s.Name == request.Name),
                cancellationToken);

            if (regStatus == null)
                throw new SignUpStatusNotExistsException(request.Name);

            return regStatus.Id;
        }
    }
}