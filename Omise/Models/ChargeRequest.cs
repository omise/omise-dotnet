﻿using Newtonsoft.Json;
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
        [JsonProperty("webhook_endpoints")]
        public string[] WebhookEndpoints { get; set; }
        public FlowTypes Flow { get; set; }
        [JsonProperty("installment_terms")]
        public int? InstallmentTerms { get; set; }
        [JsonProperty("return_uri")]
        public string ReturnUri { get; set; }
        [JsonProperty("platform_fee")]
        public PlatformFeeRequest PlatformFee { get; set; }

        public CreateChargeRequest()
        {
            Capture = true;
        }
    }
    public class PlatformFeeRequest : Request
    {
        public long? Fixed { get; set; }
        public long? Percentage { get; set; }
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
