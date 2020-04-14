using Newtonsoft.Json;
using System.Collections.Generic;

namespace Omise.Models
{
    public class CreateTransferParams : Params
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("fail_fast")]
        public bool FailFast { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
        [JsonProperty("recipient")]
        public string Recipient { get; set; }
    }

    public class UpdateTransferParams : Params
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
    }
}