using Newtonsoft.Json;

namespace Omise.Models
{
    public class UpdateCardRequest : Request
    {
        public string Name { get; set; }
        public string City { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("expiration_month")]
        public int? ExpirationMonth { get; set; }
        [JsonProperty("expiration_year")]
        public int? ExpirationYear { get; set; }
    }
}