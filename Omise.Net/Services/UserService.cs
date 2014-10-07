using System;

namespace Omise
{
	public class UserService: ServiceBase
	{
		public UserService (string apiKey): base(apiKey)
		{
		}

		public UserService (IRequestManager requestManager, string apiKey): base(requestManager, apiKey)
		{
		}
	}
}

