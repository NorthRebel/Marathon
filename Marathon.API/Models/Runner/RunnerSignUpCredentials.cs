using System;
using Newtonsoft.Json;

namespace Marathon.API.Models.Runner
{
    public class RunnerSignUpCredentials
    {
        [JsonProperty]
        public uint UserId { get; set; }

        [JsonProperty]
        public char GenderId { get; set; }

        [JsonProperty]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty]
        public string CountryId { get; set; }

        [JsonProperty]
        public byte[] Photo { get; set; }
    }
}
