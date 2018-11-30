using MediatR;

namespace Marathon.Application.Users.Queries.GetUserType
{
    /// <summary>
    /// Gets user's privileges type code by name
    /// </summary>
    public sealed class GetUserTypeQuery : IRequest<char>
    {
        public string Name { get; set; }

        public GetUserTypeQuery(string name)
        {
            Name = name;
        }
    }
}
