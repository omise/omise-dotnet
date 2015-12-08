using System;
using Omise.Resources;
using Omise.Models;
using NUnit.Framework;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class TokenResourceTest : ResourceTest<TokenResource> {
        [Test]
        public async void TestCreate() {
            var request = new CreateTokenRequest
            {
                Name = "VISA RichGuy",
                Number = "4242424242424242",
                ExpirationMonth = 12,
                ExpirationYear = 2099,
            };

            await Resource.Create(request);
            AssertRequest("POST", "https://vault.omise.co/tokens");
        }

        [Test]
        public async void TestGet() {
            await Resource.Get("tok_test_789");
            AssertRequest("GET", "https://vault.omise.co/tokens/tok_test_789");
        }

        protected override TokenResource BuildResource(IRequester requester) {
            return new TokenResource(requester);
        }
    }
}

