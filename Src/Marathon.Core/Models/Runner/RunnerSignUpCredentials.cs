using System;
using Newtonsoft.Json;

namespace Marathon.Core.Models.Runner
{
    public class RunnerSignUpCredentials
    {
        [JsonProperty]
        public int UserId { get; set; }

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
