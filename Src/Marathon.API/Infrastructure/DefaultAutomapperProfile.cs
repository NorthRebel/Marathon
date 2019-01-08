using AutoMapper;
using Marathon.API.Models.User;
using Marathon.Domain.Entities;

namespace Marathon.API.Infrastructure
{
    public class DefaultAutomapperProfile : Profile
    {
        public DefaultAutomapperProfile()
        {
            CreateMap<User, UserInfo>()
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => src.UserTypeId))
                .ForMember(dest => dest.Token, opt => opt.MapFrom<UserTokenResolver>());
        }
    }
}
