using System.Threading.Tasks;
using Marathon.Core.Models.User;

namespace Marathon.Core.Services.User
{
    public interface IUserService
    {
        Task<UserInfo> SignInAsync(string email, string password);
    }
}
