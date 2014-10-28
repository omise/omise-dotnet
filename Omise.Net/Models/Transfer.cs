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
    }
}

