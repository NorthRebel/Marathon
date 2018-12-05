using Newtonsoft.Json;

namespace Marathon.Core.Models.User
{
    public class UserInfo
    {
        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("user_type")]
        public char UserType { get; set; }
    }
}
