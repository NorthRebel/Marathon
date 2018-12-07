﻿using Marathon.Core.Helpers;
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

        public Task<UserInfo> SignInAsync(UserSignInCredentials credentials)
        {
            var uri = UriHelper.CombineUri(GlobalSettings.Instance.SignIn);
            return _requestProvider.PostAsync<UserSignInCredentials, UserInfo>(uri, credentials);
        }

        public Task<UserInfo> SignUpAsync(UserSignUpCredentials credentials)
        {
            var uri = UriHelper.CombineUri(GlobalSettings.Instance.SignIn);
            return _requestProvider.PostAsync<UserSignUpCredentials, UserInfo>(uri, credentials);
        }
    }
}
