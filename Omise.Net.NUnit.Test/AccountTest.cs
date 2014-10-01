using System;
using NUnit.Framework;

namespace Omise.Net.NUnit.Test
{
	[TestFixture]
	public class AccountTest:TestBase
	{
		[Test]
		public void TestGetAccount(){
			var account = client.AccountService.GetAccount ();
			Assert.IsNotNull (account);
			Assert.IsNotNullOrEmpty (account.Email);
			Assert.IsNotNull (account.CreatedAt);
		}
	}
}

