using Newtonsoft.Json;

namespace Marathon.API.Models.Marathon
{
    public class EventType
    {
        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }
    }
}
