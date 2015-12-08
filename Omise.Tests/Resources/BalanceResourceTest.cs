using System;
using NUnit.Framework;
using Omise.Resources;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class BalanceResourceTest : ResourceTest {
        [Test]
        public async void TestGet() {
            var resource = new BalanceResource(Requester);
            await resource.Get();

            AssertRequest("GET", "https://api.omise.co/balance");
        }
    }
}

