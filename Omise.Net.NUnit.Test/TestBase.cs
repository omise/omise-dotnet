using System;
using NUnit.Framework;

namespace Omise.Net.NUnit.Test
{
	public abstract class TestBase
	{
		protected string apiKey = "skey_test_4xhm5bi59825tfoq3s2";
		protected string apiUrlBase = "http://api.lvh.me:3000";
		protected Omise.Client client;

		[SetUp]
		public virtual void Setup(){
			client = new Omise.Client (this.apiKey, this.apiUrlBase);
		}

		[TearDown]
		public virtual void Teardown(){
			client = null;
		}
	}
}

