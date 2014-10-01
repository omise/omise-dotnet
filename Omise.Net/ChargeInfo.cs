using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Omise
{
	public class ChargeInfo : RequestObject
	{
		public ChargeInfo ()
		{
			errors = new Dictionary<string, string> ();
		}

		private Dictionary<string, string> errors{ get; set; }

		public int Amount{ get; set; }

		public string Currency{ get; set; }

		public string Description{ get; set; }

		public string ReturnUri{ get; set; }

		public string Reference{ get; set; }

		public CardInfo Card{ get; set; } 

		public string CardId{ get; set; }

		public string CustomerId{ get; set; }

		public bool Capture{get;set;}

		public override string ToRequestParams ()
		{
			var dict = new Dictionary<string, string>();
			dict.Add ("amount", this.Amount.ToString());
			dict.Add ("currency", this.Currency);
			dict.Add ("description", this.Description);
			dict.Add ("return_uri", this.ReturnUri);
			dict.Add ("capture", this.Capture.ToString());
			if (CustomerId != null) {
				dict.Add ("customer", CustomerId);
			}

			if (CardId != null) {
				dict.Add ("card", CardId);
			}

			if (Card != null) {
				dict.Add ("card[number]", Card.Number);
				dict.Add ("card[expiration_month]", Card.ExpirationMonth);
				dict.Add ("card[expiration_year]", Card.ExpirationYear);
				dict.Add ("card[name]", Card.Name);
			}

			string result = "";

			foreach (string key in dict.Keys)
			{
				result += key.ToLower() + "=" + dict[key] + "&";
			}

			return result.TrimEnd(new[]{ '&' });
		}

		public override bool Valid {
			get {
				validate ();
				return errors.Count==0;
			}
		}

		public override Dictionary<string, string> Errors {
			get {
				return errors;
			}
		}

		protected override void validate ()
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

			if (this.Card == null && this.CardId==null) {
				if (this.CustomerId == null) {
					errors.Add ("Card", "cannot be blank. You can use card id, card token or card hash. You can also pass CustomerId to use the customer's default card.");
				}
			} else if (this.Card!=null && !this.Card.Valid) {
				errors.Add ("Card", "is invalid");
			}
		}
	}
}

