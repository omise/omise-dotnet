﻿using Newtonsoft.Json;

namespace Omise.Models
{
    // Will be serialized wrapped in a "card" key.
    // See TokenResource for more info.
    public class CreateTokenRequest : Request
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("expiration_month")]
        public int ExpirationMonth { get; set; }
        [JsonProperty("expiration_year")]
        public int ExpirationYear { get; set; }

        [JsonProperty("security_code")]
        public string SecurityCode { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
    }
}