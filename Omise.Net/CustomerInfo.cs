using System;
using System.Collections.Generic;

namespace Omise
{
	public class CustomerInfo: RequestObject
	{
		private Dictionary<string, string> errors{ get; set; }
		public string Email{get;set;}
		public string Description{ get; set;}
		public CustomerInfo ()
		{
			errors = new Dictionary<string, string> ();
		}

		protected override void validate ()
		{
			errors.Clear ();
			if (string.IsNullOrEmpty(Email)) {
				errors.Add ("email", "cannot be blank");
			}
		}

		public override bool Valid {
			get {
				validate ();
				return errors.Count==0;
			}
		}

		public override string ToRequestParams ()
		{
			var dict = new Dictionary<string, string>();
			dict.Add ("email", this.Email.ToString());
			dict.Add ("description", this.Description);

			string result = "";

			foreach (string key in dict.Keys)
			{
				result += key.ToLower() + "=" + dict[key] + "&";
			}

			return result.TrimEnd(new[]{ '&' });
		}
	}
}

