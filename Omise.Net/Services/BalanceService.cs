using System;

namespace Omise
{
	public class BalanceService: ServiceBase
	{
		public BalanceService (string apiUrlBase, string apiKey): base(apiUrlBase, apiKey)
		{
		}

		public Balance GetBalance(){
			string result = requester.ExecuteRequest ("balance", "GET", null);
			return balanceFactory.Create (result);
		}
	}
}

