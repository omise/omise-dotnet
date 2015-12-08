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
            var requester = BuildRequester();
            var resource = new CustomerResource(requester);

            await resource.GetList();
            AssertRequest(requester, "GET", "https://api.omise.co/customers");
        }

        [Test]
        public async void TestGet() {
            var requester = BuildRequester();
            var resource = new CustomerResource(requester);

            await resource.Get("cust_test_123");
            AssertRequest(requester, "GET", "https://api.omise.co/customers/cust_test_123");
        }

        [Test]
        public async void TestCreate() {
            var requester = BuildRequester();
            var resource = new CustomerResource(requester);
            var request = new CreateCustomerRequest
            {
                Email = "support@omise.co",
                Description = "Omise support",
                Card = "card_test_123"
            };

            await resource.Create(request);
            AssertRequest(requester, "POST", "https://api.omise.co/customers");
        }

        [Test]
        public async void TestUpdate() {
            var requester = BuildRequester();
            var resource = new CustomerResource(requester);
            var request = new UpdateCustomerRequest
            {
                Email = "example@omise.co",
                Description = "Omise example",
                Card = "card_test_456"
            };

            await resource.Update("cust_test_123", request);
            AssertRequest(requester, "PATCH", "https://api.omise.co/customers/cust_test_123");
        }

        [Test]
        public async void TestDestroy() {
            var requester = BuildRequester();
            var resource = new CustomerResource(requester);

            await resource.Destroy("cust_test_123");
            AssertRequest(requester, "DELETE", "https://api.omise.co/customers/cust_test_123");
        }
    }
}

