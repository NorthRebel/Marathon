using Newtonsoft.Json;

namespace Marathon.Core.Models.User
{
    public class UserInfo
    {
        [JsonProperty]
        public uint Id { get; set; }

        [JsonProperty]
        public char UserType { get; set; }
    }
}
