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

        protected override AccountResource BuildResource(IRequester requester) {
            return new AccountResource(requester);
        }
    }
}

