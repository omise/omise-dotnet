using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Omise.Models
{
    public class TransferScheduling
    {
        public string Recipient { get; set; }
        public long Amount { get; set; }
        public string Currency { get; set; }
        [JsonProperty("percentage_of_balance")]
        public float PercentageOfBalance { get; set; }
    }
}
