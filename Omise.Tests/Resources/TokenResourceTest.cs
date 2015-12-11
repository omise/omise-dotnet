using System;
using Omise.Resources;
using Omise.Models;
using NUnit.Framework;
using System.Diagnostics.Contracts;
using System.Dynamic;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class TokenResourceTest : ResourceTest<TokenResource> {
        const string TokenId = "tokn_test_4yq8lbecl0q6dsjzxr5";

        [Test]
        public async void TestCreate() {
            await Resource.Create(BuildCreateRequest());
            AssertRequest("POST", "https://vault.omise.co/tokens");
        }

        [Test]
        public async void TestGet() {
            await Resource.Get(TokenId);
            AssertRequest("GET", "https://vault.omise.co/tokens/{0}", TokenId);
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

        [Test]
        public async void TestFixturesCreate() {
            var token = await Fixtures.Create(new CreateTokenRequest());
            Assert.AreEqual(TokenId, token.Id);
            Assert.AreEqual("4242", token.Card.LastDigits);
        }

        [Test]
        public async void TestFixturesGet() {
            var token = await Fixtures.Get(TokenId);
            Assert.AreEqual(TokenId, token.Id);
            Assert.AreEqual("4242", token.Card.LastDigits);
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

