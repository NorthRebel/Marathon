using Newtonsoft.Json;

namespace Marathon.API.Models.Charity
{
    public class Charity
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }
    }
}
