using System;

namespace Omise
{
	public class BalanceService: ServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.BalanceService"/> class with api url and api key. The service uses default request manager object.
		/// </summary>
		/// <param name="apiUrlBase">API base URL.</param>
		/// <param name="apiKey">API key.</param>
		public BalanceService (string apiUrlBase, string apiKey): base(apiUrlBase, apiKey)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.BalanceService"/> class with IRequestManager object, api url and api key.
		/// </summary>
		/// <param name="requestManager">IRequestManager object.</param>
		/// <param name="apiUrlBase">API base url.</param>
		/// <param name="apiKey">API key.</param>
		public BalanceService (IRequestManager requestManager, string apiUrlBase, string apiKey): base(requestManager, apiUrlBase, apiKey)
		{
		}

		/// <summary>
		/// Gets the Omise balance information.
		/// </summary>
		/// <returns>The balance object.</returns>
		public Balance GetBalance(){
			string result = requester.ExecuteRequest ("balance", "GET", null);
			return balanceFactory.Create (result);
		}
	}
}

