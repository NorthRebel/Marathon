using Newtonsoft.Json;

namespace Marathon.API.Models
{
    public class Gender
    {
        [JsonProperty]
        public char Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }
    }
}
