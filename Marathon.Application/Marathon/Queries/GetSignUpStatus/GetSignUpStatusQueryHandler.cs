using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;
using Marathon.Domain.Entities;
using Marathon.DAL.Repositories;
using Marathon.Application.Users.Exceptions;

namespace Marathon.Application.Marathon.Queries.GetSignUpStatus
{
    /// <summary>
    /// Handles <see cref="GetSignUpStatusQuery"/>
    /// </summary>
    public sealed class GetSignUpStatusQueryHandler : IRequestHandler<GetSignUpStatusQuery, byte>
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public GetSignUpStatusQueryHandler(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task<byte> Handle(GetSignUpStatusQuery request, CancellationToken cancellationToken)
        {
            using (IUnitOfWork context = _uowFactory.Create())
            {
                SignUpStatus signUpStatus = await context.SignUpStatuses.GetSingleAsync(s => s.Name == request.Name, cancellationToken);

                if (signUpStatus == null)
                    throw new SignUpStatusNotExistsException(request.Name);

                return signUpStatus.Id;
            }
        }
    }
}