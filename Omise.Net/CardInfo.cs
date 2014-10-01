using System;
using System.Collections.Generic;

namespace Omise
{

	public class CardInfo : RequestObject
	{
		private Dictionary<string, string> errors{ get; set; }

		public string City{get;set;}

		public string PostalCode{get;set;}

		public string ExpirationMonth{ get; set; }

		public string ExpirationYear{ get; set; }

		public string Number{ get; set; }

		public string Name{ get; set; }

		public CardInfo ()
		{
			errors = new Dictionary<string, string> ();
		}

		public override string ToRequestParams ()
		{
			var dict = new Dictionary<string, string>();
			dict.Add ("number", this.Number);
			dict.Add ("name", this.Name);
			dict.Add ("expiration_month", this.ExpirationMonth);
			dict.Add ("expiration_year", this.ExpirationYear);

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

			if (string.IsNullOrEmpty(this.Name)) {
				errors.Add ("name", "cannot be blank");
			}

			if (string.IsNullOrEmpty(this.Number)) {
				errors.Add ("number", "cannot be blank");
			}

			if (string.IsNullOrEmpty (this.ExpirationMonth)) {
				errors.Add ("ExpirationMonth", "cannot be blank");
			}

			if (string.IsNullOrEmpty (this.ExpirationYear)) {
				errors.Add ("ExpirationYear", "cannot be blank");
			}
		}
	}
}

