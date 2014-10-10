using System;
using System.Collections.Generic;

namespace Omise
{
    /// <summary>
    /// Provides helper methods for converting dictionary to another object type
    /// </summary>
	public class DictionaryHelper
	{
        /// <summary>
        /// Initialize a DictionaryHelper object
        /// </summary>
		public DictionaryHelper ()
		{
		}

        /// <summary>
        /// Convert to dictionary object to a string
        /// </summary>
        /// <param name="dict">a Dictionary object</param>
        /// <returns>a String representing a specified dictionary</returns>
		public static string ToString(Dictionary<string, string> dict){
			if (dict == null)
				throw new InvalidOperationException ("Dictionary cannot be null");

			string result = "";

			foreach (string key in dict.Keys)
			{
				result += key.ToLower() + " : " + dict[key] + ", ";
			}

			return result.Trim().TrimEnd(new[]{ ',' });
		}
	}
}

