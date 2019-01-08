using Newtonsoft.Json;

namespace Marathon.Core.Models.Charity
{
    public class Charity
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }
    }
}
