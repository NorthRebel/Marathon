using Marathon.Core.Helpers;
using System.Threading.Tasks;
using Marathon.Core.Models.User;
using Marathon.Core.Services.RequestProvider;

namespace Marathon.Core.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRequestProvider _requestProvider;

        public UserService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<UserInfo> SignInAsync(string email, string password)
        {
            var uri = UriHelper.CombineUri(GlobalSettings.Instance.SignIn);

            var userInfo = await _requestProvider.GetAsync<UserInfo>(uri);
            return userInfo;
        }
    }
}
