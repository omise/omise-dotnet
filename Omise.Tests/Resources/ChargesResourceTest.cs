using System;
using NUnit.Framework;
using Omise.Resources;
using Omise.Models;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class ChargesResourceTest : ResourceTest {
        [Test]
        public async void TestGetList() {
            var requester = BuildRequester();
            var resource = new ChargesResource(requester);

            await resource.GetList();
            AssertRequest(requester, "GET", "https://api.omise.co/charges");
        }

        [Test]
        public async void TestGet() {
            var requester = BuildRequester();
            var resource = new ChargesResource(requester);

            await resource.Get("xyz");
            AssertRequest(requester, "GET", "https://api.omise.co/charges/xyz");
        }

        [Test]
        public async void TestCreate() {
            var requester = BuildRequester();
            var resource = new ChargesResource(requester);
            var request = new CreateChargeRequest
            {
                Customer = "cust_test_123",
                Card = "card_test_456",
                Amount = 2448,
                Currency = "thb",
            };
                    
            await resource.Create(request);
            AssertRequest(requester, "POST", "https://api.omise.co/charges");
        }

        [Test]
        public async void TestUpdate() {
            var requester = BuildRequester();
            var resource = new ChargesResource(requester);
            var request = new UpdateChargeRequest
            {
                Description = "Hello charge",
            };

            await resource.Update("chrg_test_123", request);
            AssertRequest(requester, "PATCH", "https://api.omise.co/charges/chrg_test_123");
        }

        [Test]
        public async void TestCapture() {
            var requester = BuildRequester();
            var resource = new ChargesResource(requester);

            await resource.Capture("chrg_test_123");
            AssertRequest(requester, "POST", "https://api.omise.co/charges/chrg_test_123/capture");
        }
    }
}

