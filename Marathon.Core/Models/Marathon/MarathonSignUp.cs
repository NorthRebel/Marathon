using Newtonsoft.Json;

namespace Marathon.Core.Models.Marathon
{
    public class MarathonSignUp
    {
        [JsonProperty]
        public int RunnerId { get; set; }

        [JsonProperty]
        public int CharityId { get; set; }

        [JsonProperty]
        public char RaceKitOptionId { get; set; }

        [JsonProperty]
        public string EventTypeId { get; set; }

        [JsonProperty]
        public decimal Cost { get; set; }

        [JsonProperty]
        public decimal SponsorshipTarget { get; set; }
    }
}
