using System.Threading.Tasks;
using Marathon.API.Models.User;

namespace Marathon.API.Services
{
    public interface IUserService : IService
    {
        Task<UserInfo> SignInAsync(UserSignInCredentials credentials);
        Task<UserInfo> SignUpAsync(UserSignUpCredentials credentials);
    }
}
