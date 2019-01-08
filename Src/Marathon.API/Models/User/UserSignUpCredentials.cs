using System.Security;
using Newtonsoft.Json;

namespace Marathon.API.Models.User
{
    public class UserSignUpCredentials
    {
        [JsonProperty]
        public string Email { get; set; }

        [JsonProperty]
        public string Password { get; set; }

        [JsonProperty]
        public string FirstName { get; set; }

        [JsonProperty]
        public string LastName { get; set; }

        [JsonProperty]
        public char UserTypeId { get; set; }
    }
}
