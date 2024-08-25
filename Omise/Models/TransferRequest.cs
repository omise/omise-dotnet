using System.Collections.Generic;
using Newtonsoft.Json;

namespace Omise.Models
{
    public class CreateTransferRequest : Request
    {
        public long? Amount { get; set; }
        public string? Recipient { get; set; }
        [JsonProperty("fail_fast")]
        public bool? FailFast { get; set; }
        [JsonProperty("split_transfer")]
        public bool? SplitTransfer { get; set; }
        [JsonProperty("idemp_key")]
        public string? IdempKey { get; set; }
        public IDictionary<string, object>? Metadata { get; set; }
    }
}