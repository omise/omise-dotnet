using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omise
{
    public class Dispute : ResponseObject
    {
        [JsonProperty("livemode")]
        public bool LiveMode { get; set; }
        
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("amount")]
        public int Amount { get;  set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
        
        [JsonProperty("status")]
        public DisputeStatus Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("charge")]
        public string ChargeId { get; set; }
    }
}
