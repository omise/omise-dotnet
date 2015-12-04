using System.Linq;
using NUnit.Framework;
using Omise.Resources;
using Omise.Models;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class AccountResourceTest : ResourceTest {
        [Test]
        public async void TestGet() {
            var requester = BuildRequester();
            var resource = new AccountResource(requester);
            await resource.Get();

            AssertRequest(requester.Requests.Last(),
                "GET", "https://api.omise.co/account");
        }
    }
}

