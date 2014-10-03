using System;

namespace Omise
{
	public class UserService: ServiceBase
	{
		public UserService (string apiUrlBase, string apiKey): base(apiUrlBase, apiKey)
		{
		}

		public UserService (IRequestManager requestManager, string apiUrlBase, string apiKey): base(requestManager, apiUrlBase, apiKey)
		{
		}
	}
}

