using Newtonsoft.Json;

namespace Omise.Models
{
    public class CreateLinkParams : Params
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("multiple")]
        public bool Multiple { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}