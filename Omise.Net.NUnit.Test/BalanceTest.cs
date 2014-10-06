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
			string json = "{'object': 'balance','livemode': false,'available': 500,'total': 1000,'currency': 'thb'}";
			StubRequestWithResponse (json);
			var result = client.BalanceService.GetBalance ();
			Assert.IsNotNull (result);
			Assert.False (result.LiveMode);
			Assert.AreEqual (500m, result.Available);
			Assert.AreEqual (1000m, result.Total);
			Assert.AreEqual ("thb", result.Currency);
		}
	}
}

