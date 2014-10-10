using System;
using System.Collections.Generic;

namespace Omise
{
	public class CustomerInfo: RequestObject
	{
		private Dictionary<string, string> errors = new Dictionary<string, string> ();
		private string email;
		/// <summary>
		/// Gets or sets the email.
		/// </summary>
		/// <value>Customer's email</value>
		public string Email{
			get{ return email; }
			set{ email = value; }
		}

		private string description;
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>Description of the customer</value>
		public string Description{ 
			get{return description;}
			set{ description = value;}
		}

		private string cardId;
		/// <summary>
		/// Gets or sets the card id or card token.
		/// </summary>
		/// <value>The card id or card token</value>
		public string CardId{
			get{ return cardId; }
			set{ cardId = value; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.CustomerInfo"/> class.
		/// </summary>
		public CustomerInfo ()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.CustomerInfo"/> class.
		/// </summary>
		/// <param name="email">Customer's email</param>
		/// <param name="description">Description of the customer</param>
		public CustomerInfo(string email, string description){
			this.email = email;
			this.description = description;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.CustomerInfo"/> class.
        /// </summary>
        /// <param name="email">Customer's email</param>
        /// <param name="description">Description of the customer</param>
        /// <param name="cardId">Card id or card token to attach to customer</param>
        public CustomerInfo(string email, string description, string cardId)
        {
            this.email = email;
            this.description = description;
            this.cardId = cardId;
        }

		private void validate ()
		{
			errors.Clear ();
			if (string.IsNullOrEmpty(Email)) {
				errors.Add ("email", "cannot be blank");
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="Omise.CustomerInfo"/> is valid.
		/// </summary>
		/// <value><c>true</c> if valid; otherwise, <c>false</c>.</value>
		public override bool Valid {
			get {
				validate ();
				return errors.Count==0;
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
		public override string ToRequestParams ()
		{
			var dict = new Dictionary<string, string>();
			dict.Add ("email", this.Email.ToString());
			dict.Add ("description", this.Description);

			if (!string.IsNullOrEmpty (this.cardId)) {
				dict.Add ("card", this.cardId);
			}

			string result = "";

			foreach (string key in dict.Keys)
			{
				result += key.ToLower() + "=" + dict[key] + "&";
			}

			return result.TrimEnd(new[]{ '&' });
		}
	}
}

