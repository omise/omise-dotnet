using Newtonsoft.Json;

namespace Omise.Models
{
    public class CreatePaymentSourceRequest : Request
    {
        public OffsiteTypes Type { get; set; }
        public FlowTypes Flow { get; set; }
         [JsonProperty("platform_type")]
        public PlatformTypes PlatformType { get; set; }
        public long Amount { get; set; }
        public string Currency { get; set; }
        public string Barcode { get; set; }
        public string Bank { get; set; }
        public string Email { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
