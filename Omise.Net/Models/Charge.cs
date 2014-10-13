using System;
using Newtonsoft.Json;

namespace Omise
{
    /// <summary>
    /// Charge object representing charge result object
    /// </summary>
    [JsonObject]
    public class Charge : ResponseObject
    {
        /// <summary>
        /// Defines whether a charge is live mode 
        /// </summary>
        [JsonProperty("livemode")]
        public bool LiveMode { get; set; }

        /// <summary>
        /// Defines a uri for getting a charge information
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// A charge amount
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// A charge currency
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// A charge description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Defines whether a charge should be captured
        /// </summary>
        [JsonProperty("capture")]
        public bool Capture { get; set; }

        /// <summary>
        /// Defines whether a charge is authorized
        /// </summary>
        [JsonProperty("authorized")]
        public bool Authorized { get; set; }

        /// <summary>
        /// Defines whether a charge is captured
        /// </summary>
        [JsonProperty("captured")]
        public bool Captured { get; set; }

        /// <summary>
        /// A uri which the gateway will redirect to after finish captured
        /// </summary>
        [JsonProperty("return_uri")]
        public string ReturnUri { get; set; }

        /// <summary>
        /// A charge reference code
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; set; }

        /// <summary>
        /// A uri which can be used to authorize a charge
        /// </summary>
        [JsonProperty("authorize_uri")]
        public string AuthorizeUrl { get; set; }

        /// <summary>
        /// A customer id whose a charge is applied
        /// </summary>
        [JsonProperty("customer")]
        public string CustomerId { get; set; }

        /// <summary>
        /// IP address of a client who made the charge
        /// </summary>
        [JsonProperty("ip")]
        public string Ip { get; set; }

        /// <summary>
        /// Card object which the charge applied
        /// </summary>
        public Card Card { get; set; }
    }
}

