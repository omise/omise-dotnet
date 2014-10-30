using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace Omise.Net.NUnit.Test
{
    [TestFixture]
    public class AccountTest:TestBase
    {
        [Test]
        public void TestGetAccount()
        {
            string json = "{'object': 'account','id': '12345','email': 'test@omise.co','created': '2014-09-23T04:57:19Z'}";
            stubResponse(json);
            var account = client.AccountService.GetAccount();
            Assert.IsNotNull(account);
            Assert.AreEqual("12345", account.Id);
            Assert.AreEqual("test@omise.co", account.Email);
            Assert.AreEqual(new DateTime(2014, 9, 23, 4, 57, 19), account.CreatedAt);
        }
    }
}

