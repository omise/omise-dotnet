using System;
using Newtonsoft.Json;

namespace Omise
{
    [JsonObject]
    public class Recipient: ResponseObject
    {
        [JsonProperty("name")]
        public string Name{ get; set; }

        [JsonProperty("tax_id")]
        public string TaxId{ get; set; }

        [JsonProperty("email")]
        public string Email{ get; set; }

        [JsonProperty("description")]
        public string Description{ get; set; }

        [JsonProperty("recipient_type")]
        public RecipientType RecipientType{ get; set; }

        [JsonProperty("default_bank_account")]
        public string DefaultBankAccountId{ get; set; }

        [JsonProperty("livemode")]
        public bool LiveMode { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonIgnore]
        public CollectionResponseObject<BankAccount> BankAccountCollection{ get; set; }
    }
}

