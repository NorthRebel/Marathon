using Newtonsoft.Json;

namespace Marathon.API.Models.User
{
    public class UserInfo
    {
        [JsonProperty]
        public uint Id { get; set; }

        [JsonProperty]
        public char UserType { get; set; }
    }
}
