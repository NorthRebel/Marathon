using System;
using Newtonsoft.Json;

namespace Marathon.API.Models.Runner
{
    public class RunnerSignUpCredentials
    {
        [JsonProperty]
        public uint UserId { get; set; }

        [JsonProperty]
        public string Gender { get; set; }

        [JsonProperty]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty]
        public string CountryName { get; set; }

        [JsonProperty]
        public byte[] Photo { get; set; }
    }
}
