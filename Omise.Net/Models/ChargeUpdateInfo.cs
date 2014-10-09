using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Omise
{
	public class ChargeUpdateInfo : RequestObject
	{
		private Dictionary<string, string> errors = new Dictionary<string, string> ();

		private string description;
		/// <summary>
		/// Gets or sets the description of the charge
		/// </summary>
		/// <value>Charge description</value>
		public string Description{
			get{ return description;}
			set{ description = value;}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.ChargeUpdateInfo"/> class.
		/// </summary>
		public ChargeUpdateInfo (){}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.ChargeUpdateInfo"/> class.
		/// </summary>
		/// <param name="description">Description.</param>
		public ChargeUpdateInfo (string description){
			this.description = description;
		}

		/// <summary>
		/// Get the string representing the querystring parameters
		/// </summary>
		/// <returns>The request parameters</returns>
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

		/// <summary>
		/// Gets a value indicating whether this <see cref="Omise.ChargeUpdateInfo"/> is valid.
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
		/// <value>The errors dictionary object</value>
		public override Dictionary<string, string> Errors {
			get {
				return errors;
			}
		}

		private void validate ()
		{
		}
	}
}

