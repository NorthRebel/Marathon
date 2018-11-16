using MediatR;

namespace Marathon.Application.Marathon.Queries.GetSignUpStatus
{
    /// <summary>
    /// Gets runner's marathon sign up status code by name
    /// </summary>
    public sealed class GetSignUpStatusQuery : IRequest<long>
    {
        public string Name { get; set; }

        public GetSignUpStatusQuery(string name)
        {
            Name = name;
        }
    }
}