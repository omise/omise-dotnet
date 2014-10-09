using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Omise
{
	public class ChargeCreateInfo : RequestObject
	{
		private Dictionary<string, string> errors = new Dictionary<string, string> ();

		private int amount;

		/// <summary>
		/// Gets or sets the amount
		/// </summary>
		/// <value>Charge amount</value>
		public int Amount { 
			get{ return amount; }
			set{ amount = value; }
		}

		private string currency;
		/// <summary>
		/// Gets or sets the currency
		/// </summary>
		/// <value>Charge currency</value>
		public string Currency { 
			get{ return currency; }
			set{ currency = value; }
		}

		private string description;
		/// <summary>
		/// Gets or sets the description
		/// </summary>
		/// <value>Charge description</value>
		public string Description {
			get{ return description; }
			set{ description = value; }
		}

		private string returnUri;
		/// <summary>
		/// Gets or sets the return URI when charging is completed
		/// </summary>
		/// <value>Return URI</value>
		public string ReturnUri {
			get{ return returnUri; }
			set{ returnUri = value; }
		}

		private string reference;
		/// <summary>
		/// Gets or sets the charge reference number
		/// </summary>
		/// <value>The charge reference number</value>
		public string Reference {
			get{ return reference; }
			set{ reference = value; }
		}

		private string cardId;
		/// <summary>
		/// Gets or sets the card Id
		/// </summary>
		/// <value>Card Id</value>
		public string CardId {
			get{ return cardId; }
			set{ cardId = value; }
		}

		private string customerId;
		/// <summary>
		/// Gets or sets the customer Id
		/// </summary>
		/// <value>The customer identifier</value>
		public string CustomerId {
			get{ return customerId; }
			set{ customerId = value; }
		}

		private bool capture;
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Omise.ChargeInfo"/> will be automatic capture
		/// </summary>
		/// <value><c>true</c> if capture; otherwise, <c>false</c></value>
		public bool Capture {
			get{ return capture; }
			set{ capture = value; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.ChargeInfo"/> class.
		/// </summary>
		public ChargeCreateInfo ()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.ChargeCreateInfo"/> class with a specific customer's card.
		/// </summary>
		/// <param name="amount">Amount</param>
		/// <param name="currency">Currency</param>
		/// <param name="description">Description</param>
		/// <param name="returnUri">Return URI</param>
		/// <param name="reference">Reference</param>
		/// <param name="cardId">Card Id or Card Token</param>
		/// <param name="customerId">Customer Id</param>
		public ChargeCreateInfo (int amount, string currency, string description, string returnUri, string reference, string cardId, string customerId)
		{
			this.amount = amount;
			this.currency = currency;
			this.description = description;
			this.returnUri = returnUri;
			this.reference = reference;
			this.cardId = cardId;
			this.customerId = customerId;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.ChargeCreateInfo"/> class with a custom card information.
		/// </summary>
		/// <param name="amount">Amount</param>
		/// <param name="currency">Currency</param>
		/// <param name="description">Description</param>
		/// <param name="returnUri">Return URI</param>
		/// <param name="reference">Reference</param>
		/// <param name="cardCreateInfo">Card information</param>
		public ChargeCreateInfo (int amount, string currency, string description, string returnUri, string reference)
		{
			this.amount = amount;
			this.currency = currency;
			this.description = description;
			this.returnUri = returnUri;
			this.reference = reference;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.ChargeCreateInfo"/> class with default customer's card.
		/// </summary>
		/// <param name="amount">Amount</param>
		/// <param name="currency">Currency</param>
		/// <param name="description">Description</param>
		/// <param name="returnUri">Return URI</param>
		/// <param name="reference">Reference</param>
		/// <param name="customerId">Customer Id</param>
		public ChargeCreateInfo (int amount, string currency, string description, string returnUri, string reference, string customerId)
		{
			this.amount = amount;
			this.currency = currency;
			this.description = description;
			this.returnUri = returnUri;
			this.reference = reference;
			this.customerId = customerId;
		}

		/// <summary>
		/// Get the string representing the querystring parameters
		/// </summary>
		/// <returns>The request parameters</returns>
		public override string ToRequestParams ()
		{
			var dict = new Dictionary<string, string> ();
			dict.Add ("amount", this.Amount.ToString ());
			dict.Add ("currency", this.Currency);
			dict.Add ("description", this.Description);
			dict.Add ("return_uri", this.ReturnUri);
			dict.Add ("capture", this.Capture.ToString ());
			if (CustomerId != null) {
				dict.Add ("customer", CustomerId);
			}

			if (CardId != null) {
				dict.Add ("card", CardId);
			}

			string result = "";

			foreach (string key in dict.Keys) {
				result += key.ToLower () + "=" + dict [key] + "&";
			}

			return result.TrimEnd (new[]{ '&' });
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="Omise.ChargeInfo"/> is valid.
		/// </summary>
		/// <value><c>true</c> if valid; otherwise, <c>false</c></value>
		public override bool Valid {
			get {
				validate ();
				return errors.Count == 0;
			}
		}

		/// <summary>
		/// Gets the errors dictionary.
		/// </summary>
		/// <value>The errors dictionary object</value>
		public override Dictionary<string, string> Errors {
			get {
				return errors;
			}
		}

		private void validate ()
		{
			errors.Clear ();
			if (this.Amount <= 0) {
				errors.Add ("Amount", "must be greater than 0");
			}

			if (string.IsNullOrEmpty (this.Currency)) {
				errors.Add ("Currency", "cannot be blank");
			}

			if (string.IsNullOrEmpty (this.ReturnUri)) {
				errors.Add ("ReturnUri", "cannot be blank");
			}

			if (string.IsNullOrEmpty(this.CardId)) {
				if (string.IsNullOrEmpty(this.CustomerId)) {
					errors.Add ("CardId", "cannot be blank. You can use card id or card token. You can also pass CustomerId to use the customer's default card.");
				}
			}
		}
	}
}

