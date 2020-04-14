using Newtonsoft.Json;

namespace Omise.Models
{
    public class CardParams : Params
    {
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("expiration_month")]
        public long ExpirationMonth { get; set; }
        [JsonProperty("expiration_year")]
        public long ExpirationYear { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("number")]
        public string Number { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        [JsonProperty("security_code")]
        public string SecurityCode { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("street1")]
        public string Street1 { get; set; }
        [JsonProperty("street2")]
        public string Street2 { get; set; }
    }
}