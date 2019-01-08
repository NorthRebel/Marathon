using System.Threading.Tasks;
using Marathon.Core.Models.User;

namespace Marathon.Core.Services.Interfaces
{
    public interface IUserService : IService
    {
        Task<UserInfo> SignInAsync(UserSignInCredentials credentials);
        Task<UserInfo> SignUpAsync(UserSignUpCredentials credentials);
    }
}
