using System;

namespace Omise
{
	public class AccountService: ServiceBase
	{
		public AccountService (string apiUrlBase, string apiKey): base(apiUrlBase, apiKey)
		{
		}

		public Account GetAccount(){
			var result = requester.ExecuteRequest("/account", "GET", null);
			return accountFactory.Create (result);
		}
	}
}

