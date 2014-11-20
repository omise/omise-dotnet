using System;
using Newtonsoft.Json;

namespace Omise
{
    [JsonObject]
    public class BankAccount: ResponseObject
    {
        [JsonProperty("bank_id")]
        public string BankId{ get; set; }

        [JsonProperty("bank_account_no")]
        public string BankAccountNumber{ get; set; }

        [JsonProperty("bank_account_name")]
        public string BankAccountName{ get; set; }
    }
}

