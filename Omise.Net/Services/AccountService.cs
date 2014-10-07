using System;

namespace Omise
{
	public class AccountService: ServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.AccountService"/> class with api url and api key. The service uses default request manager object.
		/// </summary>
		/// <param name="apiUrlBase">API URL base.</param>
		/// <param name="apiKey">API key.</param>
		public AccountService (string apiKey): base(apiKey)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.AccountService"/> class with IRequestManager object, api url and api key.
		/// </summary>
		/// <param name="requestManager">IRequestManager object.</param>
		/// <param name="apiUrlBase">API base URL.</param>
		/// <param name="apiKey">API key.</param>
		public AccountService (IRequestManager requestManager, string apiKey): base(requestManager, apiKey)
		{
		}

		/// <summary>
		/// Gets the Omise account information.
		/// </summary>
		/// <returns>The Omise account object.</returns>
		public Account GetAccount(){
			var result = requester.ExecuteRequest("/account", "GET", null);
			return accountFactory.Create (result);
		}
	}
}

