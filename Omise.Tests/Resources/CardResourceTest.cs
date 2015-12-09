using System;
using Omise.Resources;
using NUnit.Framework;
using Omise.Models;
using Omise.Tests.Util;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class CardResourceTest : ResourceTest<CardResource> {
        [Test]
        public async void TestGetList() {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/customers/cust_test_123/cards");
        }
        
        [Test]
        public async void TestGet() {
            await Resource.Get("card_456");
            AssertRequest("GET", "https://api.omise.co/customers/cust_test_123/cards/card_456");
        }

        [Test]
        public async void TestUpdate() {
            await Resource.Update("card_test_456", BuildUpdateRequest());
            AssertRequest("PATCH", "https://api.omise.co/customers/cust_test_123/cards/card_test_456");
        }

        [Test]
        public async void TestDestroy() {
            await Resource.Destroy("card_test_456");
            AssertRequest("DELETE", "https://api.omise.co/customers/cust_test_123/cards/card_test_456");
        }

        [Test]
        public void TestUpdateCardRequest() {
            AssertSerializedRequest(BuildUpdateRequest(),
                "name=MasterCard%20SmartPay&" +
                "city=Bangkok&" +
                "postal_code=12345&" +
                "expiration_month=12&" +
                "expiration_year=2018"
            );
        }
            
        protected UpdateCardRequest BuildUpdateRequest() {
            return new UpdateCardRequest
            {
                Name = "MasterCard SmartPay",
                City = "Bangkok",
                PostalCode = "12345",
                ExpirationMonth = 12,
                ExpirationYear = 2018,
            };
        }

        protected override CardResource BuildResource(IRequester requester) {
            return new CardResource(requester, "cust_test_123");
        }
    }
}

