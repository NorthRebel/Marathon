using Newtonsoft.Json;

namespace Marathon.Core.Models.Charity
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
