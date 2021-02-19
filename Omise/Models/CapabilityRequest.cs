using System.Collections.Generic;
using Newtonsoft.Json;

namespace Omise.Models
{
    public class CreateCapabilityRequest : Request
    {
        public List<string> Banks { get; set; }
        public string Country { get; set; }
        [JsonProperty("payment_methods")]
        public List<PaymentMethod> PaymentMethods { get; set; }
        [JsonProperty("zero_interest_installments")]
        public bool ZeroInterestInstallments { get; set; }
    }
}
