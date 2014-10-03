using System;

namespace Omise
{
	public interface IRequestManager
	{
		/// <summary>
		/// Executes the request and return result string
		/// </summary>
		/// <returns>Response string</returns>
		/// <param name="path">Path</param>
		/// <param name="method">Method</param>
		/// <param name="payload">Request payload</param>
		string ExecuteRequest (string path, string method, string payload);
	}
}

