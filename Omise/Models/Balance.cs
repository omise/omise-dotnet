using System;
using Newtonsoft.Json;

namespace Omise.Models {
    /// <summary>
    /// Omise Balance object
    /// </summary>
    [JsonObject]
    public class Balance : ResponseObject {
        /// <summary>
        /// Defines whether the Balance is live
        /// </summary>
        [JsonProperty("livemode")]
        public bool LiveMode { get; set; }

        /// <summary>
        /// Defines available amount of balance
        /// </summary>
        [JsonProperty("available")]
        public decimal Available { get; set; }

        /// <summary>
        /// Defines total amount of balance
        /// </summary>
        [JsonProperty("total")]
        public decimal Total { get; set; }

        /// <summary>
        /// Defines currency of balance
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}

