using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;
using Marathon.DAL.Repositories;
using Marathon.Application.Users.Exceptions;

namespace Marathon.Application.Users.Queries.GetUserType
{
    /// <summary>
    /// Handles <see cref="GetUserTypeQuery"/>
    /// </summary>
    public sealed class GetUserTypeQueryHandler : IRequestHandler<GetUserTypeQuery, char>
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public GetUserTypeQueryHandler(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task<char> Handle(GetUserTypeQuery request, CancellationToken cancellationToken)
        {
            using (IUnitOfWork context = _uowFactory.Create())
            {
                var userType = await context.UserTypes.GetSingleAsync(ut => ut.Name == request.Name, cancellationToken);

                if (userType == null)
                    throw new UserTypeNotExistsException(request.Name);

                return userType.Id;
            }
        }
    }
}
