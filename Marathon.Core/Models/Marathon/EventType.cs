using Newtonsoft.Json;

namespace Marathon.Core.Models.Marathon
{
    public class EventType
    {
        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }
    }
}
