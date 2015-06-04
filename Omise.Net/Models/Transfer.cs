using System;
using Newtonsoft.Json;

namespace Omise
{
    /// <summary>
    /// An object specifies a balance transfer information
    /// </summary>
    [JsonObject]
    public class Transfer : ResponseObject
    {
        /// <summary>
        /// Amount of the transfer
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Currency of the transfer
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("sent")]
        public bool Sent{ get; set; }

        [JsonProperty("paid")]
        public bool Paid{ get; set; }

        [JsonProperty("recipient")]
        public string RecipientId { get; set; }
        
        [JsonProperty("bank_account")]
        public BankAccount BankAccount { get; set; }

        [JsonProperty("failure_code")]
        public string FailureCode{ get; set; }

        [JsonProperty("failure_message")]
        public string FailureMessage{ get; set; }

        [JsonProperty("transaction")]
        public string TransactionId{ get; set; }

        [JsonProperty("livemode")]
        public bool LiveMode { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
    }
}

