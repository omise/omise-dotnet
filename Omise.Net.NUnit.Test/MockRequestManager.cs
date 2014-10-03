using System;

namespace Omise.Net.NUnit.Test
{
	public class MockRequestManager: IRequestManager
	{
		public MockRequestManager ()
		{
		}

		public virtual string ExecuteRequest (string path, string method, string payload){
			return string.Empty;
		}
	}
}

