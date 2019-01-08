using Newtonsoft.Json;

namespace Marathon.API.Models
{
    public class Country
    {
        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }
    }
}
