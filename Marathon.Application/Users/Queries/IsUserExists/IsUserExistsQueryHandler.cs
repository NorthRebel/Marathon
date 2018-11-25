using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;
using Marathon.DAL.Repositories;

namespace Marathon.Application.Users.Queries.IsUserExists
{
    /// <summary>
    /// Handles <see cref="IsUserExistsQuery"/>
    /// </summary>
    public sealed class IsUserExistsQueryHandler : IRequestHandler<IsUserExistsQuery, bool>
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public IsUserExistsQueryHandler(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task<bool> Handle(IsUserExistsQuery request, CancellationToken cancellationToken)
        {
            using (IUnitOfWork context = _uowFactory.Create())
            {
                var userExists = await context.Users.GetSingleAsync(u => u.Email == request.Email, cancellationToken);

                return userExists != null;
            }
        }
    }
}
