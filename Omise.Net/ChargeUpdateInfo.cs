using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Omise
{
	public class ChargeUpdateInfo : RequestObject
	{
		public ChargeUpdateInfo ()
		{
			errors = new Dictionary<string, string> ();
		}

		private Dictionary<string, string> errors{ get; set; }

		public string Description{ get; set; }

		public override string ToRequestParams ()
		{
			var dict = new Dictionary<string, string>();
			dict.Add ("description", this.Description);

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
		}
	}
}

