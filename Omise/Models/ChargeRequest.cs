using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Omise.Models
{
    public class CreateChargeRequest : Request
    {
        public string? Customer { get; set; }
        public string? Card { get; set; }
        public long Amount { get; set; }
        [JsonProperty("authorization_type")]
        // Explicit convertor setting as the serializer is not converting this enum properly
        [JsonConverter(typeof(EnumValueConverter))]
        public AuthTypes? AuthorizationType { get; set; }
        public string Currency { get; set; }
        public string? Description { get; set; }
        [JsonProperty("expires_at")]
        public DateTime? ExpiresAt { get; set; }
        public IDictionary<string, object>? Metadata { get; set; }
        public bool? Capture { get; set; }
        public CreatePaymentSourceRequest? Source { get; set; }
        [JsonProperty("webhook_endpoints")]
        public string[]? WebhookEndpoints { get; set; }
        [JsonProperty("return_uri")]
        public string? ReturnUri { get; set; }
        [JsonProperty("platform_fee")]
        public PlatformFeeRequest? PlatformFee { get; set; }
        [JsonProperty("first_charge")]
        public string? FirstCharge { get; set; }
         public string? Ip { get; set; }
         [JsonProperty("linked_account")]
         public string? LinkedAccount { get; set; }
         [JsonProperty("recurring_reason")]
         public RecurringReason? RecurringReason { get; set; }
         [JsonProperty("transaction_indicator")]
         public string? TransactionIndicator { get; set; }
         [JsonProperty("zero_interest_installments")]
         public bool? ZeroInterestInstallments { get; set; }

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
        public string? Description { get; set; }
        public IDictionary<string, object>? Metadata { get; set; }
    }
    public class CaptureChargeRequest : Request
    {
        [JsonProperty("capture_amount")]
        public long? CaptureAmount { get; set; }

    }
}
