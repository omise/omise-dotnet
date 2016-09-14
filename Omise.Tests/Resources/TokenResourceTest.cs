using System.Threading.Tasks;
using NUnit.Framework;
using Omise.Models;
using Omise.Resources;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class TokenResourceTest : ResourceTest<TokenResource> {
        const string TokenId = "tokn_test_4yq8lbecl0q6dsjzxr5";

        [Test]
        public async Task TestCreate() {
            await Resource.Create(BuildCreateRequest());
            AssertRequest("POST", "https://vault.omise.co/tokens");
        }

        [Test]
        public async Task TestGet() {
            await Resource.Get(TokenId);
            AssertRequest("GET", "https://vault.omise.co/tokens/{0}", TokenId);
        }

        [Test]
        public void TestCreateTokenRequest() {
            AssertSerializedRequest(BuildCreateRequest(),
                "card%5Bname%5D=VISA+RichGuy&" +
                "card%5Bnumber%5D=4242424242424242&" +
                "card%5Bexpiration_month%5D=12&" +
                "card%5Bexpiration_year%5D=2099&" +
                "card%5Bsecurity_code%5D=xyz&" +
                "card%5Bcity%5D=Bangkok&" +
                "card%5Bpostal_code%5D=43424"
            );
        }

        [Test]
        public async Task TestFixturesCreate() {
            var token = await Fixtures.Create(new CreateTokenRequest());
            Assert.AreEqual(TokenId, token.Id);
            Assert.AreEqual("4242", token.Card.LastDigits);
        }

        [Test]
        public async Task TestFixturesGet() {
            var token = await Fixtures.Get(TokenId);
            Assert.AreEqual(TokenId, token.Id);
            Assert.AreEqual("4242", token.Card.LastDigits);
        }

        protected CreateTokenRequest BuildCreateRequest() {
            return new CreateTokenRequest {
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

