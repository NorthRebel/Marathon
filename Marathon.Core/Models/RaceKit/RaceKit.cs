using Newtonsoft.Json;

namespace Marathon.Core.Models.RaceKit
{
    public class RaceKit
    {
        [JsonProperty]
        public char Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public decimal Cost { get; set; }
    }
}
