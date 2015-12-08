using System.Linq;
using NUnit.Framework;
using Omise.Resources;
using Omise.Models;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class AccountResourceTest : ResourceTest {
        [Test]
        public async void TestGet() {
            var resource = new AccountResource(Requester);
            await resource.Get();

            AssertRequest("GET", "https://api.omise.co/account");
        }
    }
}

