using MediatR;

namespace Marathon.Application.Users.Queries.IsUserExists
{
    /// <summary>
    /// Checks user exists by email
    /// </summary>
    public sealed class IsUserExistsQuery : IRequest<bool>
    {
        public string Email { get; set; }
    }
}
