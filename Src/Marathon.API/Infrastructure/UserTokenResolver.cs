using AutoMapper;
using Marathon.API.Authentication;
using Marathon.API.Models.User;
using Marathon.Domain.Entities;

namespace Marathon.API.Infrastructure
{
    public class UserTokenResolver : IValueResolver<User, UserInfo, string>
    {
        public string Resolve(User source, UserInfo destination, string destMember, ResolutionContext context)
        {
            return source.GenerateJwtToken();
        }
    }
}
