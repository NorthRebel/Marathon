using System;

namespace Marathon.Core.Models.User
{
    [Serializable]
    public class UserInfo
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public char UserType { get; set; }

        public static UserInfo ConvertFromApiModel(API.Models.User.UserInfo apiModel)
        {
            return new UserInfo
            {
                Id = apiModel.Id,
                Token = apiModel.Token,
                UserType = apiModel.UserType
            };
        }
    }
}
