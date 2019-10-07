using Newtonsoft.Json;

namespace Omise.Models
{
    public partial class ChargeScheduling
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("card")]
        public string Card { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("customer")]
        public string Customer { get; set; }
        [JsonProperty("default_card")]
        public bool DefaultCard { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}