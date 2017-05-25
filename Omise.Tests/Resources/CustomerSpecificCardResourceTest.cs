using System.Threading.Tasks;
using NUnit.Framework;
using Omise.Models;
using Omise.Resources;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class CustomerSpecificCardResourceTest : ResourceTest<CustomerSpecificCardResource>
    {
        const string CustomerId = "cust_test_4yq6txdpfadhbaqnwp3";
        const string CardId = "card_test_4yq6tuucl9h4erukfl0";

        [Test]
        public async Task TestGetList()
        {
            await Resource.GetList();
            AssertRequest("GET", $"https://api.omise.co/customers/{CustomerId}/cards");
        }

        [Test]
        public async Task TestGet()
        {
            await Resource.Get(CardId);
            AssertRequest("GET", $"https://api.omise.co/customers/{CustomerId}/cards/{CardId}");
        }

        [Test]
        public async Task TestUpdate()
        {
            await Resource.Update(CardId, BuildUpdateRequest());
            AssertRequest("PATCH", $"https://api.omise.co/customers/{CustomerId}/cards/{CardId}");
        }

        [Test]
        public async Task TestDestroy()
        {
            await Resource.Destroy(CardId);
            AssertRequest("DELETE", $"https://api.omise.co/customers/{CustomerId}/cards/{CardId}");
        }

        [Test]
        public void TestUpdateCardRequest()
        {
            AssertSerializedRequest(
                BuildUpdateRequest(),
                @"{""name"":""MasterCard SmartPay""," +
                @"""city"":""Bangkok""," +
                @"""postal_code"":""12345""," +
                @"""expiration_month"":12," +
                @"""expiration_year"":2018}"
            );
        }

        [Test]
        public void TestUpdateCardRequest_NameOnly()
        {
            var request = BuildUpdateRequest();
            request.PostalCode = null;
            request.ExpirationMonth = null;
            request.ExpirationYear = null;

            AssertSerializedRequest(
                request,
                @"{""name"":""MasterCard SmartPay""," +
                @"""city"":""Bangkok""}"
            );
        }

        [Test]
        public async Task TestFixturesGetList()
        {
            var list = await Fixtures.GetList();
            Assert.AreEqual(1, list.Count);

            var card = list[0];
            Assert.AreEqual(CardId, card.Id);
            Assert.AreEqual("4242", card.LastDigits);
        }

        [Test]
        public async Task TestFixturesGet()
        {
            var card = await Fixtures.Get(CardId);
            Assert.AreEqual(CardId, card.Id);
            Assert.AreEqual("4242", card.LastDigits);
        }

        [Test]
        public async Task TestFixturesUpdate()
        {
            var card = await Fixtures.Update(CardId, new UpdateCardRequest());
            Assert.AreEqual(CardId, card.Id);
            Assert.AreEqual("JOHN W. DOE", card.Name);
        }

        [Test]
        public async Task TestFixturesDestroy()
        {
            var card = await Fixtures.Destroy(CardId);
            Assert.AreEqual(CardId, card.Id);
            Assert.IsTrue(card.Deleted);
        }

        protected UpdateCardRequest BuildUpdateRequest()
        {
            return new UpdateCardRequest
            {
                Name = "MasterCard SmartPay",
                City = "Bangkok",
                PostalCode = "12345",
                ExpirationMonth = 12,
                ExpirationYear = 2018,
            };
        }

        protected override CustomerSpecificCardResource BuildResource(IRequester requester)
        {
            return new CustomerSpecificCardResource(requester, CustomerId);
        }
    }
}

