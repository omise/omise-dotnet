using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Omise
{
    /// <summary>
    /// A Card token which can be safely transferred trough the API request. The token can only be used once.
    /// </summary>
    [JsonObject]
    public class Token : ResponseObject
    {
        /// <summary>
        /// Specify whether the token is live mode
        /// </summary>
        [JsonProperty("livemode")]
        public bool LiveMode { get; set; }

        /// <summary>
        /// Specify the uri of the api for getting the token information 
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Specify whether the token has been used already
        /// </summary>
        [JsonProperty("used")]
        public bool Used { get; set; }

        /// <summary>
        /// Card information
        /// </summary>
        [JsonIgnore]
        public Card Card { get; set; }
    }
}

