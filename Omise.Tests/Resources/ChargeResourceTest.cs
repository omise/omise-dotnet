using System;
using NUnit.Framework;
using Omise.Resources;
using Omise.Models;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class ChargeResourceTest : ResourceTest<ChargeResource> {
        [Test]
        public async void TestGetList() {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/charges");
        }

        [Test]
        public async void TestGet() {
            await Resource.Get("xyz");
            AssertRequest("GET", "https://api.omise.co/charges/xyz");
        }

        [Test]
        public async void TestCreate() {
            var request = new CreateChargeRequest
            {
                Customer = "cust_test_123",
                Card = "card_test_456",
                Amount = 2448,
                Currency = "thb",
            };
                    
            await Resource.Create(request);
            AssertRequest("POST", "https://api.omise.co/charges");
        }

        [Test]
        public async void TestUpdate() {
            var request = new UpdateChargeRequest
            {
                Description = "Hello charge",
            };

            await Resource.Update("chrg_test_123", request);
            AssertRequest("PATCH", "https://api.omise.co/charges/chrg_test_123");
        }

        [Test]
        public async void TestCapture() {
            await Resource.Capture("chrg_test_123");
            AssertRequest("POST", "https://api.omise.co/charges/chrg_test_123/capture");
        }

        protected override ChargeResource BuildResource(IRequester requester) {
            return new ChargeResource(requester);
        }
    }
}

