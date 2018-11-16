using MediatR;

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
}