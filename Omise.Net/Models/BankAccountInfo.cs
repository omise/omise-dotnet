using System;
using System.Collections.Generic;

namespace Omise
{
    public class BankAccountInfo: RequestObject
    {
        private Dictionary<string, string> errors = new Dictionary<string, string>();

        private string brand;

        public string Brand
        { 
            get { return brand; } 
            set { brand = value; } 
        }

        private string number;

        public string Number
        { 
            get { return number; } 
            set { number = value; }
        }

        private string name;

        public string Name
        { 
            get { return name; } 
            set { name = value; } 
        }

        public override string ToRequestParams()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("brand", this.brand);
            dict.Add("number", this.number);
            dict.Add("name", this.name);

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

            if (string.IsNullOrEmpty(this.brand))
            {
                errors.Add("Brand", "cannot be blank");
            }

            if (string.IsNullOrEmpty(this.number))
            {
                errors.Add("Number", "cannot be blank");
            }

            if (string.IsNullOrEmpty(this.name))
            {
                errors.Add("Name", "cannot be blank");
            }
        }
    }
}

