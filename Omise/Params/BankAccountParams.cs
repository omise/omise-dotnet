using Newtonsoft.Json;

namespace Omise.Models
{
    public class BankAccountParams : Params
    {
        [JsonProperty("bank_code")]
        public string BankCode { get; set; }
        [JsonProperty("branch_code")]
        public string BranchCode { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("number")]
        public string Number { get; set; }
        [JsonProperty("type")]
        public BankAccountType? Type { get; set; }
    }
}