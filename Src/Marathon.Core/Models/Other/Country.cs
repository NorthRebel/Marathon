using Newtonsoft.Json;

namespace Marathon.Core.Models.Other
{
    public class Country
    {
        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }
    }
}
