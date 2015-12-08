using System;
using NUnit.Framework;
using Omise.Resources;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class BalanceResourceTest : ResourceTest {
        [Test]
        public async void TestGet() {
            var requester = BuildRequester();
            var resource = new BalanceResource(requester);
            await resource.Get();

            AssertRequest(requester, "GET", "https://api.omise.co/balance");
        }
    }
}

