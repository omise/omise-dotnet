using System;
using System.Collections.Generic;

namespace Omise
{
    /// <summary>
    /// Defines information for creating a customer
    /// </summary>
    public class CustomerCreateInfo : RequestObject
    {
        private Dictionary<string, string> errors = new Dictionary<string, string>();
        private string email;
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>Customer's email</value>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string description;
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>Description of the customer</value>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string cardToken;
        /// <summary>
        /// Gets or sets the card token.
        /// </summary>
        /// <value>The card token</value>
        public string CardToken
        {
            get { return cardToken; }
            set { cardToken = value; }
        }

        private CardCreateInfo cardCreateInfo;
        public CardCreateInfo CardCreateInfo {
            get { return cardCreateInfo; }
            set { cardCreateInfo = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.CustomerCreateInfo"/> class.
        /// </summary>
        public CustomerCreateInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.CustomerCreateInfo"/> class.
        /// </summary>
        /// <param name="email">Customer's email</param>
        /// <param name="description">Description of the customer</param>
        public CustomerCreateInfo(string email, string description)
        {
            this.email = email;
            this.description = description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.CustomerCreateInfo"/> class.
        /// </summary>
        /// <param name="email">Customer's email</param>
        /// <param name="description">Description of the customer</param>
        /// <param name="cardId">Credit card id or card token to attach to customer</param>
        public CustomerCreateInfo(string email, string description, string cardId)
        {
            this.email = email;
            this.description = description;
            this.cardToken = cardId;
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="Omise.CustomerCreateInfo"/> class.
        /// </summary>
        /// <param name="email">Customer's email</param>
        /// <param name="description">Description of the customer</param>
        /// <param name="cardCreateInfo">Credit card information to attach to customer</param>
        public CustomerCreateInfo(string email, string description, CardCreateInfo cardCreateInfo) {
            this.email = email;
            this.description = description;
            this.cardCreateInfo = cardCreateInfo;
        }

        private void validate()
        {
            errors.Clear();
            if (!string.IsNullOrEmpty(this.cardToken) && cardCreateInfo != null)
            {
                errors.Add("card", "Specifying both card id and card dictionary is not allowed");
            }

            if (this.cardCreateInfo != null && string.IsNullOrEmpty(this.cardToken)) {
                if (!this.cardCreateInfo.Valid) {
                    errors.Add("card", "Card information is invalid");
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Omise.CustomerCreateInfo"/> is valid.
        /// </summary>
        /// <value><c>true</c> if valid; otherwise, <c>false</c>.</value>
        public override bool Valid
        {
            get
            {
                validate();
                return errors.Count == 0;
            }
        }

        /// <summary>
        /// Gets the errors dictionary.
        /// </summary>
        /// <value>The errors dictionary object.</value>
        public override Dictionary<string, string> Errors
        {
            get
            {
                return errors;
            }
        }

        /// <summary>
        /// Get the string representing the querystring parameters
        /// </summary>
        /// <returns>The request parameters</returns>
        public override string ToRequestParams()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("email", this.Email.ToString());
            dict.Add("description", this.Description);

            if (!string.IsNullOrEmpty(this.cardToken))
            {
                dict.Add("card", this.cardToken);
            }

            string result = "";

            foreach (string key in dict.Keys)
            {
                result += key.ToLower() + "=" + dict[key] + "&";
            }

            return result.TrimEnd(new[] { '&' });
        }
    }
}

