using System;
using NUnit.Framework;
using Omise.Resources;
using Omise.Models;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class ChargesResourceTest : ResourceTest {
        [Test]
        public async void TestGetList() {
            var resource = new ChargesResource(Requester);

            await resource.GetList();
            AssertRequest("GET", "https://api.omise.co/charges");
        }

        [Test]
        public async void TestGet() {
            var resource = new ChargesResource(Requester);

            await resource.Get("xyz");
            AssertRequest("GET", "https://api.omise.co/charges/xyz");
        }

        [Test]
        public async void TestCreate() {
            var resource = new ChargesResource(Requester);
            var request = new CreateChargeRequest
            {
                Customer = "cust_test_123",
                Card = "card_test_456",
                Amount = 2448,
                Currency = "thb",
            };
                    
            await resource.Create(request);
            AssertRequest("POST", "https://api.omise.co/charges");
        }

        [Test]
        public async void TestUpdate() {
            var resource = new ChargesResource(Requester);
            var request = new UpdateChargeRequest
            {
                Description = "Hello charge",
            };

            await resource.Update("chrg_test_123", request);
            AssertRequest("PATCH", "https://api.omise.co/charges/chrg_test_123");
        }

        [Test]
        public async void TestCapture() {
            var resource = new ChargesResource(Requester);

            await resource.Capture("chrg_test_123");
            AssertRequest("POST", "https://api.omise.co/charges/chrg_test_123/capture");
        }
    }
}

