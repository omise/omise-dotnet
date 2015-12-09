using System;
using Omise.Resources;
using Omise.Models;
using NUnit.Framework;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class TokenResourceTest : ResourceTest<TokenResource> {
        [Test]
        public async void TestCreate() {
            await Resource.Create(BuildCreateRequest());
            AssertRequest("POST", "https://vault.omise.co/tokens");
        }

        [Test]
        public async void TestGet() {
            await Resource.Get("tok_test_789");
            AssertRequest("GET", "https://vault.omise.co/tokens/tok_test_789");
        }

        [Test]
        public void TestCreateTokenRequest() {
            AssertSerializedRequest(BuildCreateRequest(),
                "card[name]=VISA%20RichGuy&" +
                "card[number]=4242424242424242&" +
                "card[expiration_month]=12&" +
                "card[expiration_year]=2099&" +
                "card[security_code]=xyz&" +
                "card[city]=Bangkok&" +
                "card[postal_code]=43424"
            );
        }

        protected CreateTokenRequest BuildCreateRequest() {
            return new CreateTokenRequest
            {
                Name = "VISA RichGuy",
                Number = "4242424242424242",
                ExpirationMonth = 12,
                ExpirationYear = 2099,
                SecurityCode = "xyz",
                City = "Bangkok",
                PostalCode = "43424",
            };
        }

        protected override TokenResource BuildResource(IRequester requester) {
            return new TokenResource(requester);
        }
    }
}

