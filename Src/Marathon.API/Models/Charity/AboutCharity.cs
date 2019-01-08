using Newtonsoft.Json;

namespace Marathon.API.Models.Charity
{
    public class AboutCharity
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public byte[] Logo { get; set; }
    }
}
