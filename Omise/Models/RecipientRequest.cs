using Newtonsoft.Json;

namespace Omise.Models {
    public class CreateRecipientRequest : RecipientRequest {
    }

    public class UpdateRecipientRequest : RecipientRequest {
    }

    public class RecipientRequest : Request {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public RecipientType Type { get; set; }

        [JsonProperty("tax_id")]
        public string TaxID { get; set; }

        [JsonProperty("bank_account")]
        public BankAccountRequest BankAccount { get; set; }
    }
}