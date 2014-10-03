using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace Omise.Net.NUnit.Test
{
	[TestFixture]
	public class AccountTest:TestBase
	{
		[Test]
		public void TestGetAccount(){
			string json = "{'object': 'account','id': '12345','email': 'tommy@omise.co','created': '2014-09-23T04:57:19Z'}";
			StubRequestWithResponse (json);
			var account = client.AccountService.GetAccount ();
			Assert.IsNotNull (account);
			Assert.IsNotNullOrEmpty (account.Email);
			Assert.IsNotNull (account.CreatedAt);
		}
	}
}

