using Marathon.API.Services;
using Marathon.Core.Helpers;
using System.Threading.Tasks;
using Marathon.API.Models.User;
using Marathon.Core.Services.Interfaces;

namespace Marathon.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRequestProvider _requestProvider;

        public UserService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public Task<UserInfo> SignInAsync(UserSignInCredentials credentials)
        {
            var uri = UriHelper.CombineUri(GlobalSettings.Instance.UserSignIn);
            return _requestProvider.PostAsync<UserSignInCredentials, UserInfo>(uri, credentials);
        }

        public Task<UserInfo> SignUpAsync(UserSignUpCredentials credentials)
        {
            var uri = UriHelper.CombineUri(GlobalSettings.Instance.UserSignUp);
            return _requestProvider.PostAsync<UserSignUpCredentials, UserInfo>(uri, credentials);
        }
    }
}
