using Newtonsoft.Json;

namespace Marathon.Core.Models.Other
{
    public class Gender
    {
        [JsonProperty]
        public char Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }
    }
}
