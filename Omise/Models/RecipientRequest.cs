using System;

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
        public string TaxID { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}

