using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Omise.Models
{
    public class CreateChargeParams : Params
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("capture")]
        public bool Capture { get; set; }
        [JsonProperty("card")]
        public string Card { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("customer")]
        public string Customer { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("expires_at")]
        public DateTime? ExpiresAt { get; set; }
        [JsonProperty("ip")]
        public string Ip { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
        [JsonProperty("offsite")]
        public string Offsite { get; set; }
        [JsonProperty("platform_fee")]
        public PlatformFee PlatformFee { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("return_uri")]
        public string ReturnUri { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
    }

    public class CreateChargeRefundParams : Params
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
        [JsonProperty("void")]
        public bool Void { get; set; }
    }

    public class UpdateChargeParams : Params
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
    }
}