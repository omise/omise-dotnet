using System;
using NUnit.Framework;
using Omise.Resources;
using Newtonsoft.Json.Schema;
using Omise.Models;
using System.Resources;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class CustomerResourceTest : ResourceTest {
        [Test]
        public async void TestGetList() {
            var resource = new CustomerResource(Requester);

            await resource.GetList();
            AssertRequest("GET", "https://api.omise.co/customers");
        }

        [Test]
        public async void TestGet() {
            var resource = new CustomerResource(Requester);

            await resource.Get("cust_test_123");
            AssertRequest("GET", "https://api.omise.co/customers/cust_test_123");
        }

        [Test]
        public async void TestCreate() {
            var resource = new CustomerResource(Requester);
            var request = new CreateCustomerRequest
            {
                Email = "support@omise.co",
                Description = "Omise support",
                Card = "card_test_123"
            };

            await resource.Create(request);
            AssertRequest("POST", "https://api.omise.co/customers");
        }

        [Test]
        public async void TestUpdate() {
            var resource = new CustomerResource(Requester);
            var request = new UpdateCustomerRequest
            {
                Email = "example@omise.co",
                Description = "Omise example",
                Card = "card_test_456"
            };

            await resource.Update("cust_test_123", request);
            AssertRequest("PATCH", "https://api.omise.co/customers/cust_test_123");
        }

        [Test]
        public async void TestDestroy() {
            var resource = new CustomerResource(Requester);

            await resource.Destroy("cust_test_123");
            AssertRequest("DELETE", "https://api.omise.co/customers/cust_test_123");
        }
    }
}

