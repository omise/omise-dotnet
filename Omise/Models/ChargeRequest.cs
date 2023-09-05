using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Omise.Models
{
    public class CreateChargeRequest : Request
    {
        public string Customer { get; set; }
        public string Card { get; set; }
        public long Amount { get; set; }
        [JsonProperty("authorization_type")]
        public AuthTypes AuthorizationType { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        [JsonProperty("expires_at")]
        public DateTime? ExpiresAt { get; set; }
        public IDictionary<string, object> Metadata { get; set; }
        public bool Capture { get; set; }
        public OffsiteTypes Offsite { get; set; }
        public PaymentSource Source { get; set; }
        public FlowTypes Flow { get; set; }
        [JsonProperty("installment_terms")]
        public int? InstallmentTerms { get; set; }
        [JsonProperty("return_uri")]
        public string ReturnUri { get; set; }

        public CreateChargeRequest()
        {
            Capture = true;
        }
    }

    public class UpdateChargeRequest : Request
    {
        public string Description { get; set; }
        public IDictionary<string, object> Metadata { get; set; }
    }
    public class CaptureChargeRequest : Request
    {
        [JsonProperty("capture_amount")]
        public long CaptureAmount { get; set; }

    }
}
