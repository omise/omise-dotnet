using System;
using Newtonsoft.Json;

namespace Omise
{
    [JsonObject]
    public class Refund: ResponseObject
    {
        public Refund()
        {
        }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("charge")]
        public string ChargeId{ get; set; }

        public Charge Charge { get; set; }

        [JsonProperty("transaction")]
        public string TransactionId{ get; set; }

        public Transaction Transaction{ get; set; }

        [JsonProperty("currency")]
        public string Currency{ get; set; }
    }
}

