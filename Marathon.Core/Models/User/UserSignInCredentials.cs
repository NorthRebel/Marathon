using System.Security;
using Newtonsoft.Json;

namespace Marathon.Core.Models.User
{
    public class UserSignInCredentials
    {
        [JsonProperty]
        public string Email { get; set; }

        [JsonProperty]
        public string Password { get; set; }
    }
}
