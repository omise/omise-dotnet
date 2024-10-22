using System.Collections.Generic;
using Newtonsoft.Json;

namespace Omise.Models
{
    public class CreatePaymentSourceRequest : Request
    {
        public OffsiteTypes Type { get; set; }
        public FlowTypes? Flow { get; set; }
        [JsonProperty("platform_type")]
        public PlatformTypes? PlatformType { get; set; }
        public long Amount { get; set; }
        public string Currency { get; set; }
        public string? Barcode { get; set; }
        public string? Bank { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        [JsonProperty("phone_number")]
        public string? PhoneNumber { get; set; }
        [JsonProperty("installment_term")]
        public string? InstallmentTerm { get; set; }
        [JsonProperty("promotion_code")]
        public string? PromotionCode { get; set; }
        [JsonProperty("store_id")]
        public string? StoreId { get; set; }
        [JsonProperty("store_name")]
        public string? StoreName { get; set; }
        [JsonProperty("terminal_id")]
        public string? TerminalId { get; set; }
        [JsonProperty("zero_interest_installments")]
        public bool? ZeroInterestInstallments { get; set; }
        public string? Ip { get; set; }
        public Billing? Billing { get; set; }
        public Shipping? Shipping { get; set; }
        public List<Item>? Items { get; set; }
    }
}
