using MediatR;

namespace Marathon.Application.Users.Queries
{
    /// <summary>
    /// Checks user exists by email
    /// </summary>
    public sealed class CheckUserQuery : IRequest<bool>
    {
        public string Email { get; set; }
    }
}
