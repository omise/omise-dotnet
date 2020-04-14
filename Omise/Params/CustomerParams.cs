using Newtonsoft.Json;
using System.Collections.Generic;

namespace Omise.Models
{
    public class CreateCustomerParams : Params
    {
        [JsonProperty("card")]
        public string Card { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
    }

    public class UpdateCustomerCardParams : Params
    {
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("expiration_month")]
        public long? ExpirationMonth { get; set; }
        [JsonProperty("expiration_year")]
        public long? ExpirationYear { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
    }

    public class UpdateCustomerParams : Params
    {
        [JsonProperty("card")]
        public string Card { get; set; }
        [JsonProperty("default_card")]
        public string DefaultCard { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
    }
}