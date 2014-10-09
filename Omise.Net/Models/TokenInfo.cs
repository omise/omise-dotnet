using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Omise
{
	public class TokenInfo: RequestObject
	{
		private Dictionary<string, string> errors{ get; set; }
		public CardCreateInfo Card{ get; set;}
		public TokenInfo ()
		{
			errors = new Dictionary<string, string> ();
		}

		public override string ToRequestParams ()
		{
			var dict = new Dictionary<string, string>();

			if (Card != null) {
				dict.Add ("card[number]", Card.Number);
				dict.Add ("card[expiration_month]", Card.ExpirationMonth.ToString());
				dict.Add ("card[expiration_year]", Card.ExpirationYear.ToString());
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

		private void validate ()
		{
			errors.Clear ();
			if (this.Card == null) {
				errors.Add ("Card", "cannot be blank.");
			} else if (this.Card!=null && !this.Card.Valid) {
				errors.Add ("Card", "is invalid");
			}
		}

	}
}

