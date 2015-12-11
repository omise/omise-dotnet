using System.Linq;
using NUnit.Framework;
using Omise.Resources;
using Omise.Models;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class AccountResourceTest : ResourceTest<AccountResource> {
        [Test]
        public async void TestGet() {
            await Resource.Get();
            AssertRequest("GET", "https://api.omise.co/account");
        }

        [Test]
        public async void TestFixturesGet() {
            var account = await Fixtures.Get();
            Assert.AreEqual("acct_4yq6tcsyoged5c0ocxd", account.Id);
        }

        protected override AccountResource BuildResource(IRequester requester) {
            return new AccountResource(requester);
        }
    }
}

