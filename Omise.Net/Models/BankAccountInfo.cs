using System;
using System.Collections.Generic;

namespace Omise
{
    public class BankAccountInfo: RequestObject
    {
        private Dictionary<string, string> errors = new Dictionary<string, string>();

        private string bankId;

        public string BankId
        { 
            get { return bankId; } 
            set { bankId = value; } 
        }

        private string bankAccountNumber;

        public string BankAccountNumber
        { 
            get { return bankAccountNumber; } 
            set { bankAccountNumber = value; }
        }

        private string bankAccountName;

        public string BankAccountName
        { 
            get { return bankAccountName; } 
            set { bankAccountName = value; } 
        }

        public override string ToRequestParams()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("bank_id", this.bankId);
            dict.Add("bank_account_no", this.bankAccountNumber);
            dict.Add("bank_account_name", this.bankAccountName);

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

            if (string.IsNullOrEmpty(this.bankId))
            {
                errors.Add("BankId", "cannot be blank");
            }

            if (string.IsNullOrEmpty(this.bankAccountNumber))
            {
                errors.Add("BankAccountNumber", "cannot be blank");
            }

            if (string.IsNullOrEmpty(this.bankAccountName))
            {
                errors.Add("BankAccountName", "cannot be blank");
            }
        }
    }
}

