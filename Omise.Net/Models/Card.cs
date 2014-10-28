using System;
using Newtonsoft.Json;

namespace Omise
{
    /// <summary>
    /// Omise Card object
    /// </summary>
    [JsonObject]
    public class Card : ResponseObject
    {
        /// <summary>
        /// Uri for getting the card information
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Defines whether card object is live mode
        /// </summary>
        [JsonProperty("livemode")]
        public bool LiveMode { get; set; }

        /// <summary>
        /// Defines country of the card
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Defines city of the card
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Defines postal code of the card
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("financing")]
        public string Financing { get; set; }

        /// <summary>
        /// The last 4 digits of card number
        /// </summary>
        [JsonProperty("last_digits")]
        public string LastDigits { get; set; }

        /// <summary>
        /// A brand enum specify the brand of the card
        /// </summary>
        [JsonProperty("brand")]
        public Brand Brand { get; set; }

        /// <summary>
        /// Card's expiration month
        /// </summary>
        [JsonProperty("expiration_month")]
        public int ExpirationMonth { get; set; }

        /// <summary>
        /// Card's expiration year
        /// </summary>
        [JsonProperty("expiration_year")]
        public int ExpirationYear { get; set; }

        /// <summary>
        /// Card's fingerprint
        /// </summary>
        [JsonProperty("fingerprint")]
        public string Fingerprint { get; set; }

        /// <summary>
        /// Card's holder name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}

