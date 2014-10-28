using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Omise
{
    /// <summary>
    /// Represents the information for creating the card token
    /// </summary>
    public class TokenInfo : RequestObject
    {
        private Dictionary<string, string> errors { get; set; }

        /// <summary>
        /// Card information
        /// </summary>
        public CardCreateInfo Card { get; set; }

        /// <summary>
        /// Initialize the TokenInfo object
        /// </summary>
        public TokenInfo()
        {
            errors = new Dictionary<string, string>();
        }

        /// <summary>
        /// Convert the object to a string for requesting the api
        /// </summary>
        /// <returns></returns>
        public override string ToRequestParams()
        {
            var dict = new Dictionary<string, string>();

            if (Card != null)
            {
                dict.Add("card[number]", Card.Number);
                dict.Add("card[expiration_month]", Card.ExpirationMonth.ToString());
                dict.Add("card[expiration_year]", Card.ExpirationYear.ToString());
                dict.Add("card[name]", Card.Name);
				dict.Add("card[security_code]", Card.SecurityCode);
            }

            string result = "";

            foreach (string key in dict.Keys)
            {
                result += key.ToLower() + "=" + dict[key] + "&";
            }

            return result.TrimEnd(new[] { '&' });
        }

        /// <summary>
        /// Defines whether the object is valid
        /// </summary>
        public override bool Valid
        {
            get
            {
                validate();
                return errors.Count == 0;
            }
        }

        /// <summary>
        /// Defines the dictionary of validation errors
        /// </summary>
        public override Dictionary<string, string> Errors
        {
            get
            {
                return errors;
            }
        }

        private void validate()
        {
            errors.Clear();
            if (this.Card == null)
            {
                errors.Add("Card", "cannot be blank.");
            }
            else if (this.Card != null && !this.Card.Valid)
            {
                errors.Add("Card", "is invalid");
            }
        }

    }
}

