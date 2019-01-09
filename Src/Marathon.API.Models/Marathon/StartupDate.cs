using System;
using Newtonsoft.Json;

namespace Marathon.API.Models.Marathon
{
    public class StartupDate
    {
        [JsonProperty]
        public DateTime Value { get; set; }
    }
}
