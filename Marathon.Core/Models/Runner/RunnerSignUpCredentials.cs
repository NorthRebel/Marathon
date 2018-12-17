using System;
using Newtonsoft.Json;

namespace Marathon.Core.Models.Runner
{
    public class RunnerSignUpCredentials
    {
        [JsonProperty]
        public int UserId { get; set; }

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
