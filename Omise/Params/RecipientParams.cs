using Newtonsoft.Json;

namespace Omise.Models
{
    public class CreateRecipientParams : Params
    {
        [JsonProperty("bank_account")]
        public BankAccountParams BankAccount { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("tax_id")]
        public string TaxId { get; set; }
        [JsonProperty("type")]
        public RecipientType Type { get; set; }
    }

    public class UpdateRecipientParams : Params
    {
        [JsonProperty("bank_account")]
        public BankAccountParams BankAccount { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("tax_id")]
        public string TaxId { get; set; }
        [JsonProperty("type")]
        public RecipientType Type { get; set; }
    }
}