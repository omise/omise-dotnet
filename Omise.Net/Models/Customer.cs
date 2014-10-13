using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Omise
{
    /// <summary>
    /// Customer object
    /// </summary>
    [JsonObject]
    public class Customer : ResponseObject
    {
        /// <summary>
        /// Customer's email
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Customer's description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Defines whether the customer is live mode
        /// </summary>
        [JsonProperty("livemode")]
        public bool LiveMode { get; set; }

        /// <summary>
        /// Defines whether the customer is deleted
        /// </summary>
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        /// <summary>
        /// Defines the uri for getting the customer information
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Defines the customer's default card id
        /// </summary>
        [JsonProperty("default_card")]
        public string DefaultCardId { get; set; }

        /// <summary>
        /// The CollectionResponseObject object representing cards belong to the customer
        /// </summary>
        [JsonIgnore]
        public CollectionResponseObject<Card> CardCollection { get; set; }
    }
}

