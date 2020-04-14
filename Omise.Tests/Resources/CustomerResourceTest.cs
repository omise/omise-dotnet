﻿using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;
using Omise.Models;
using Omise.Resources;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class CustomerResourceTest : ResourceTest<CustomerResource>
    {
        const string CustomerId = "cust_test_4yq6txdpfadhbaqnwp3";

        [Test]
        public async Task TestGetList()
        {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/customers");
        }

        [Test]
        public async Task TestGet()
        {
            await Resource.Get(CustomerId);
            AssertRequest("GET", "https://api.omise.co/customers/{0}", CustomerId);
        }

        [Test]
        public async Task TestCreate()
        {
            await Resource.Create(BuildCreateRequest());
            AssertRequest("POST", "https://api.omise.co/customers");
        }

        [Test]
        public async Task TestUpdate()
        {
            await Resource.Update(CustomerId, BuildUpdateRequest());
            AssertRequest("PATCH", "https://api.omise.co/customers/{0}", CustomerId);
        }

        [Test]
        public async Task TestDestroy()
        {
            await Resource.Destroy(CustomerId);
            AssertRequest("DELETE", "https://api.omise.co/customers/{0}", CustomerId);
        }

        [Test]
        public async Task TestSearch()
        {
            await Resource.Search(CustomerId);
            AssertRequest("GET", $"https://api.omise.co/search?scope=customer&query={CustomerId}");
        }

        [Test]
        public void TestCreateCustomerRequest()
        {
            AssertSerializedRequest(
                BuildCreateRequest(),
                new Dictionary<string, object>
                {
                    { "card", "card_test_123" },
                    { "description", "Omise support" },
                    { "email", "support@omise.co" },
                }
            );
        }

        [Test]
        public void TestUpdateCustomerRequest()
        {
            AssertSerializedRequest(
                BuildUpdateRequest(),
                new Dictionary<string, object>
                {
                    { "card", "card_test_456" },
                    { "default_card", "card_test_456" },
                    { "description", "Omise example" },
                    { "email", "example@omise.co" },
                }
            );
        }

        [Test]
        public async Task TestFixturesGetList()
        {
            var list = await Fixtures.GetList();
            Assert.AreEqual(1, list.Count);

            var customer = list[0];
            Assert.AreEqual(CustomerId, customer.Id);
            Assert.AreEqual("John Doe (id: 30)", customer.Description);
        }

        [Test]
        public async Task TestFixturesGet()
        {
            var customer = await Fixtures.Get(CustomerId);
            Assert.AreEqual(CustomerId, customer.Id);
            Assert.AreEqual("John Doe (id: 30)", customer.Description);
        }

        [Test]
        public async Task TestFixturesCreate()
        {
            var customer = await Fixtures.Create(new CreateCustomerParams());
            Assert.AreEqual(CustomerId, customer.Id);
            Assert.AreEqual("John Doe (id: 30)", customer.Description);
        }

        [Test]
        public async Task TestFixturesUpdate()
        {
            var customer = await Fixtures.Update(CustomerId, new UpdateCustomerParams());
            Assert.AreEqual(CustomerId, customer.Id);
            Assert.AreEqual("John Doe (id: 30)", customer.Description);
        }

        [Test]
        public async Task TestFixturesDestroy()
        {
            var customer = await Fixtures.Destroy(CustomerId);
            Assert.AreEqual(CustomerId, customer.Id);
            Assert.IsTrue(customer.Deleted);
        }

        protected CreateCustomerParams BuildCreateRequest()
        {
            return new CreateCustomerParams
            {
                Email = "support@omise.co",
                Description = "Omise support",
                Card = "card_test_123"
            };
        }

        protected UpdateCustomerParams BuildUpdateRequest()
        {
            return new UpdateCustomerParams
            {
                Email = "example@omise.co",
                Description = "Omise example",
                Card = "card_test_456",
                DefaultCard = "card_test_456"
            };
        }

        protected override CustomerResource BuildResource(IRequester requester)
        {
            return new CustomerResource(requester);
        }
    }
}

