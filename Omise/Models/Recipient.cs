using System;
using Newtonsoft.Json;

namespace Omise.Models {
    [JsonObject]
    public class Recipient: ResponseObject {
        [JsonProperty("name")]
        public string Name{ get; set; }

        [JsonProperty("tax_id")]
        public string TaxId{ get; set; }

        [JsonProperty("email")]
        public string Email{ get; set; }

        [JsonProperty("description")]
        public string Description{ get; set; }

        [JsonProperty("type")]
        public RecipientType RecipientType{ get; set; }

        [JsonProperty("livemode")]
        public bool LiveMode { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("failure_code")]
        public string FailureCode { get; set; }

        [JsonProperty("bank_account")]
        public BankAccount BankAccount{ get; set; }
    }
}

