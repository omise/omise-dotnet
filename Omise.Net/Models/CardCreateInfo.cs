using System;
using System.Collections.Generic;

namespace Omise
{
	public class CardCreateInfo : RequestObject
	{
		private Dictionary<string, string> errors = new Dictionary<string, string> ();

		private string city;

		/// <summary>
		/// Gets or sets the card city.
		/// </summary>
		/// <value>Card city</value>
		public string City {
			get{ return city; }
			set{ city = value; }
		}

		private string postalCode;

		/// <summary>
		/// Gets or sets the card postal code
		/// </summary>
		/// <value>Card postal code</value>
		public string PostalCode {
			get{ return postalCode; }
			set{ postalCode = value; }
		}

		private int expirationMonth;

		/// <summary>
		/// Gets or sets the expiration month. The valid values must be between 1 to 12.
		/// </summary>
		/// <value>The expiration month</value>
		public int ExpirationMonth { 
			get{ return expirationMonth; } 
			set{ expirationMonth = value; }
		}

		private int expirationYear;

		/// <summary>
		/// Gets or sets the expiration year
		/// </summary>
		/// <value>The expiration year</value>
		public int ExpirationYear { 
			get{ return expirationYear; }
			set{ expirationYear = value; }
		}

		private string number;

		/// <summary>
		/// Gets or sets the card number
		/// </summary>
		/// <value>Card number</value>
		public string Number { 
			get{ return number; }
			set{ number = value; }
		}

		private string name;

		/// <summary>
		/// Gets or sets the card holder's name
		/// </summary>
		/// <value>The card holder's name</value>
		public string Name { 
			get{ return name; }
			set{ name = value; }
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.CardInfo"/> class.
		/// </summary>
		public CardCreateInfo (){}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.CardInfo"/> class.
		/// </summary>
		/// <param name="name">Card holder's name</param>
		/// <param name="number">Card number</param>
		/// <param name="expirationMonth">Card expiration month</param>
		/// <param name="expirationYear">Card expiration year</param>
		/// <param name="city">Card city</param>
		/// <param name="postalCode">Card postal code</param>
		public CardCreateInfo (string name, string number, int expirationMonth, int expirationYear, string city, string postalCode)
		{
			this.name = name;
			this.number = number;
			this.expirationMonth = expirationMonth;
			this.expirationYear = expirationYear;
			this.city = city;
			this.postalCode = postalCode;
		}
		/// <summary>
		/// Get the string representing the querystring parameters
		/// </summary>
		/// <returns>The request parameters.</returns>
		public override string ToRequestParams ()
		{
			var dict = new Dictionary<string, string> ();
			dict.Add ("number", this.Number);
			dict.Add ("name", this.Name);
			dict.Add ("expiration_month", this.ExpirationMonth.ToString ());
			dict.Add ("expiration_year", this.ExpirationYear.ToString ());

			string result = "";

			foreach (string key in dict.Keys) {
				result += key.ToLower () + "=" + dict [key] + "&";
			}

			return result.TrimEnd (new[]{ '&' });
		}

		/// <summary>
		/// Check if the card is valid or not.
		/// </summary>
		/// <value><c>true</c> if valid; otherwise, <c>false</c>.</value>
		public override bool Valid {
			get {
				validate ();
				return errors.Count == 0;
			}
		}

		/// <summary>
		/// Gets the errors dictionary.
		/// </summary>
		/// <value>The errors dictionary object.</value>
		public override Dictionary<string, string> Errors {
			get {
				return errors;
			}
		}

		private void validate ()
		{
			errors.Clear ();

			if (string.IsNullOrEmpty (this.name)) {
				errors.Add ("name", "cannot be blank");
			}

			if (string.IsNullOrEmpty (this.number)) {
				errors.Add ("number", "cannot be blank");
			}

			if (this.expirationMonth < 1 || this.expirationMonth > 12) {
				errors.Add ("ExpirationMonth", "must be between 1 to 12");
			}

			if (this.expirationYear <= 0 || this.expirationYear > DateTime.Now.AddYears(20).Year) {
				errors.Add ("ExpirationYear", "is invalid.");
			}
		}
	}
}

