using Newtonsoft.Json;

namespace Omise.Models
{
    public class CreateSourceParams : Params
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("barcode")]
        public string Barcode { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("installment_term")]
        public long InstallmentTerm { get; set; }
        [JsonProperty("mobile_number")]
        public string MobileNumber { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("store_id")]
        public string StoreId { get; set; }
        [JsonProperty("store_name")]
        public string StoreName { get; set; }
        [JsonProperty("terminal_id")]
        public string TerminalId { get; set; }
        [JsonProperty("type")]
        public SourceType Type { get; set; }
        [JsonProperty("zero_interest_installments")]
        public bool ZeroInterestInstallments { get; set; }
    }
}