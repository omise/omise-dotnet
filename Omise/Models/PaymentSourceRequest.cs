using Newtonsoft.Json;

namespace Omise.Models
{
    public class CreatePaymentSourceRequest : Request
    {
        public OffsiteTypes Type { get; set; }
        public FlowTypes Flow { get; set; }
        public long Amount { get; set; }
        public string Currency { get; set; }
        public string Barcode { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
