using System.Collections.Generic;
using Newtonsoft.Json;

namespace Omise.Models
{
    public class CreateCustomerRequest : CustomerRequest
    {
    }

    public class UpdateCustomerRequest : CustomerRequest
    {
        [JsonProperty("default_card")]
        public string DefaultCard { get; set; }
    }

    public abstract class CustomerRequest : Request
    {
        public string Email { get; set; }
        public string Description { get; set; }
        public IDictionary<string, object> Metadata { get; set; }
        public string Card { get; set; }
        [JsonProperty("linked_account")]
        public string LinkedAccount { get; set; }
    }
}