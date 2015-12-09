using System;
using NUnit.Framework;
using Omise.Resources;
using Newtonsoft.Json.Schema;
using Omise.Models;
using System.Resources;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class CustomerResourceTest : ResourceTest<CustomerResource> {
        [Test]
        public async void TestGetList() {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/customers");
        }

        [Test]
        public async void TestGet() {
            await Resource.Get("cust_test_123");
            AssertRequest("GET", "https://api.omise.co/customers/cust_test_123");
        }

        [Test]
        public async void TestCreate() {
            await Resource.Create(BuildCreateRequest());
            AssertRequest("POST", "https://api.omise.co/customers");
        }

        [Test]
        public async void TestUpdate() {
            await Resource.Update("cust_test_123", BuildUpdateRequest());
            AssertRequest("PATCH", "https://api.omise.co/customers/cust_test_123");
        }

        [Test]
        public async void TestDestroy() {
            await Resource.Destroy("cust_test_123");
            AssertRequest("DELETE", "https://api.omise.co/customers/cust_test_123");
        }

        [Test]
        public void TestCreateCustomerRequest() {
            AssertSerializedRequest(BuildCreateRequest(),
                "email=support%40omise.co&" +
                "description=Omise%20support&" +
                "card=card_test_123"
            );
        }

        [Test]
        public void TestUpdateCustomerRequest() {
            AssertSerializedRequest(BuildUpdateRequest(),
                "email=example%40omise.co&" +
                "description=Omise%20example&" +
                "card=card_test_456"
            );
        }

        protected CreateCustomerRequest BuildCreateRequest() {
            return new CreateCustomerRequest
            {
                Email = "support@omise.co",
                Description = "Omise support",
                Card = "card_test_123"
            };
        }

        protected UpdateCustomerRequest BuildUpdateRequest() {
            return new UpdateCustomerRequest
            {
                Email = "example@omise.co",
                Description = "Omise example",
                Card = "card_test_456"
            };
        }

        protected override CustomerResource BuildResource(IRequester requester) {
            return new CustomerResource(requester);
        }
    }
}

