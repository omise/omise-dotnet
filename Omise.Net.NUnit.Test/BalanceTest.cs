using System;
using NUnit.Framework;

namespace Omise.Net.NUnit.Test
{
	[TestFixture]
	public class BalanceTest: TestBase
	{
		[Test]
		public void TestGetBalance(){
			var result = client.BalanceService.GetBalance ();
			Assert.IsNotNull (result);
			Assert.GreaterOrEqual (0m, result.Available);
			Assert.GreaterOrEqual (0m, result.Total);
			Assert.IsNotNullOrEmpty (result.Currency);
		}
	}
}

