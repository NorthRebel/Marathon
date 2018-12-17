using System;
using Newtonsoft.Json;

namespace Marathon.Core.Models.User
{
    [Serializable]
    public class UserInfo
    {
        /// <summary>
        /// The authentication token used to stay authenticated through future requests
        /// </summary>
        [JsonProperty]
        public string Token { get; set; }

        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public char UserType { get; set; }
    }
}
