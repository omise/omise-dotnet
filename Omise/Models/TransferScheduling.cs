using Newtonsoft.Json;

namespace Omise.Models
{
    public partial class TransferScheduling
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("percentage_of_balance")]
        public float PercentageOfBalance { get; set; }
        [JsonProperty("recipient")]
        public string Recipient { get; set; }
    }
}