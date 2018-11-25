using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;
using Marathon.Domain.Entities;
using Marathon.DAL.Repositories;
using Marathon.Application.Users.Exceptions;

namespace Marathon.Application.Users.Commands.SignIn
{
    public sealed class SignInCommandHandler : IRequestHandler<SignInCommand, User>
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public SignInCommandHandler(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task<User> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            using (IUnitOfWork context = _uowFactory.Create())
            {
                var user = await context.Users.GetSingleAsync(u => u.Email == request.Email && u.Password == request.Password, cancellationToken);

                if (user == null)
                    throw new InvalidUserCredentialsException();

                return user;
            }
        }
    }
}
