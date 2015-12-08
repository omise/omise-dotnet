using System;
using NUnit.Framework;
using Omise.Resources;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class BalanceResourceTest : ResourceTest<BalanceResource> {
        [Test]
        public async void TestGet() {
            await Resource.Get();
            AssertRequest("GET", "https://api.omise.co/balance");
        }

        protected override BalanceResource BuildResource(IRequester requester) {
            return new BalanceResource(requester);
        }
    }
}

