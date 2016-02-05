using Newtonsoft.Json;

namespace Omise.Models {
    // TODO: Test request serialization.
    public class CreateTokenRequest : Request {
        [JsonProperty("card[name]")]
        public string Name { get; set; }
        [JsonProperty("card[number]")]
        public string Number { get; set; }

        [JsonProperty("card[expiration_month]")]
        public int ExpirationMonth { get; set; }
        [JsonProperty("card[expiration_year]")]
        public int ExpirationYear { get; set; }

        [JsonProperty("card[security_code]")]
        public string SecurityCode { get; set; }
        [JsonProperty("card[city]")]
        public string City { get; set; }
        [JsonProperty("card[postal_code]")]
        public string PostalCode { get; set; }
    }
}