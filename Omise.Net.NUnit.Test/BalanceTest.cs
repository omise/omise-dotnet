using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace Omise.Net.NUnit.Test
{
	[TestFixture]
	public class BalanceTest: TestBase
	{
		[Test]
		public void TestGetBalance(){
			string json = "{'object': 'balance','livemode': false,'available': 0,'total': 0,'currency': 'thb'}";
			StubRequestWithResponse (json);
			var result = client.BalanceService.GetBalance ();
			Assert.IsNotNull (result);
			Assert.GreaterOrEqual (0m, result.Available);
			Assert.GreaterOrEqual (0m, result.Total);
			Assert.IsNotNullOrEmpty (result.Currency);
		}
	}
}

