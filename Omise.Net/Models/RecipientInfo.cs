using System;
using System.Collections.Generic;

namespace Omise
{
    public class RecipientInfo: RequestObject
    {
        private Dictionary<string, string> errors = new Dictionary<string, string>();

        private string name;

        public string Name
        { 
            get{ return name; } 
            set{ name = value; } 
        }

        private string taxId;

        public string TaxId
        { 
            get{ return taxId; } 
            set{ taxId = value; } 
        }

        private string email;

        public string Email
        { 
            get{ return email; } 
            set{ email = value; } 
        }

        private string description;

        public string Description
        { 
            get{ return description; } 
            set{ description = value; } 
        }

        private string defaultBankAccountId;

        public string DefaultBankAccountId
        { 
            get{ return defaultBankAccountId; } 
            set{ defaultBankAccountId = value; } 
        }

        private RecipientType recipientType;

        public RecipientType RecipientType
        {
            get{ return recipientType; }
            set{ recipientType = value; }
        }

        private BankAccountInfo bankAccount;

        public BankAccountInfo BankAccount
        {
            get{ return bankAccount; }
            set{ bankAccount = value; }
        }

        public override string ToRequestParams()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("name", this.name);
            dict.Add("recipient_type", this.recipientType.ToString().ToLower());

            if (!string.IsNullOrEmpty(this.email))
            {
                dict.Add("email", this.email);
            }

            if (!string.IsNullOrEmpty(this.description))
            {
                dict.Add("description", this.description);
            }

            if (!string.IsNullOrEmpty(this.taxId))
            {
                dict.Add("tax_id", this.taxId);
            }

            if (this.bankAccount != null)
            {
                dict.Add("bank_account[bank_id]", this.bankAccount.BankId);
                dict.Add("bank_account[bank_account_no]", this.bankAccount.BankAccountNumber);
                dict.Add("bank_account[bank_account_name]", this.bankAccount.BankAccountName);
            }

            string result = "";

            foreach (string key in dict.Keys)
            {
                result += key.ToLower() + "=" + dict[key] + "&";
            }

            return result.TrimEnd(new[] { '&' });
        }

        public override Dictionary<string, string> Errors
        {
            get
            {
                return errors;
            }
        }

        public override bool Valid
        {
            get
            {
                validate();
                return errors.Count == 0;
            }
        }

        private void validate()
        {
            errors.Clear();

            if (string.IsNullOrEmpty(this.name))
            {
                errors.Add("Name", "cannot be blank");
            }

            if (this.recipientType == null)
            {
                errors.Add("RecipientType", "cannot be blank");
            }
        }
    }
}

