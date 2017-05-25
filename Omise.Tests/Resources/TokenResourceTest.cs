using System.Threading.Tasks;
using NUnit.Framework;
using Omise.Models;
using Omise.Resources;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class TokenResourceTest : ResourceTest<TokenResource>
    {
        const string TokenId = "tokn_test_4yq8lbecl0q6dsjzxr5";

        [Test]
        public async Task TestCreate()
        {
            await Resource.Create(BuildCreateRequest());
            AssertRequest("POST", "https://vault.omise.co/tokens");
        }

        [Test]
        public async Task TestGet()
        {
            await Resource.Get(TokenId);
            AssertRequest("GET", "https://vault.omise.co/tokens/{0}", TokenId);
        }

        [Test]
        public void TestCreateTokenRequest()
        {
            // "card" parent key wrapped in a custom Create() method
            // (not using one from ICreatable)
            AssertSerializedRequest(
                BuildWrappedCreateRequest(),
                @"{""card"":{" +
                @"""name"":""VISA RichGuy""," +
                @"""number"":""4242424242424242""," +
                @"""expiration_month"":12," +
                @"""expiration_year"":2099," +
                @"""security_code"":""xyz""," +
                @"""city"":""Bangkok""," +
                @"""postal_code"":""43424""}}"
            );
        }

        [Test]
        public async Task TestFixturesCreate()
        {
            var token = await Fixtures.Create(new CreateTokenRequest());
            Assert.AreEqual(TokenId, token.Id);
            Assert.AreEqual("4242", token.Card.LastDigits);
        }

        [Test]
        public async Task TestFixturesGet()
        {
            var token = await Fixtures.Get(TokenId);
            Assert.AreEqual(TokenId, token.Id);
            Assert.AreEqual("4242", token.Card.LastDigits);
        }

        protected TokenRequestWrapper BuildWrappedCreateRequest()
        {
            return new TokenRequestWrapper { Card = BuildCreateRequest() };
        }

        protected CreateTokenRequest BuildCreateRequest()
        {
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

        protected override TokenResource BuildResource(IRequester requester)
        {
            return new TokenResource(requester);
        }
    }
}

