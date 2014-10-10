using System;

namespace Omise
{
    /// <summary>
    /// Defines methods for requesting User api
    /// </summary>
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

