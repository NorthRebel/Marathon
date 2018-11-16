using MediatR;

namespace Marathon.Application.Users.Queries
{
    /// <summary>
    /// Gets user's privileges type code by name
    /// </summary>
    public sealed class UserTypeQuery : IRequest<long>
    {
        public string Name { get; set; }

        public UserTypeQuery(string name)
        {
            Name = name;
        }
    }
}
