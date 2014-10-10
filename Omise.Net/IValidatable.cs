using System;
using System.Collections.Generic;

namespace Omise
{
    /// <summary>
    /// Defines methods and properties for an validatable object
    /// </summary>
	public interface IValidatable
	{
		/// <summary>
		/// Gets or sets the validation errors.
		/// </summary>
		/// <value>The errors dictionary.</value>
		Dictionary<string, string> Errors{ get; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Omise.IValidatable"/> is valid.
		/// </summary>
		/// <value><c>true</c> if valid; otherwise, <c>false</c>.</value>
		bool Valid{ get; set; }
	}
}

