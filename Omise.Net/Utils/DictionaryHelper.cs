using System;
using System.Collections.Generic;

namespace Omise
{
	public class DictionaryHelper
	{
		public DictionaryHelper ()
		{
		}

		public static string ToString(Dictionary<string, string> dict){
			if (dict == null)
				throw new InvalidOperationException ("Dictionary cannot be null");

			string result = "";

			foreach (string key in dict.Keys)
			{
				result += key.ToLower() + "=" + dict[key] + ", ";
			}

			return result.Trim().TrimEnd(new[]{ ',' });
		}
	}
}

