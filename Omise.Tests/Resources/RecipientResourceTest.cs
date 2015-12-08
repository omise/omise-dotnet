using System;
using NUnit.Framework;
using Omise.Resources;
using Newtonsoft.Json.Schema;
using Omise.Models;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class RecipientResourceTest : ResourceTest {
        RecipientResource Resource { get; set; }

        [SetUp]
        public void SetupResource() {
            Resource = new RecipientResource(Requester);
        }

        [Test]
        public async void TestGetList() {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/recipients");
        }

        [Test]
        public async void TestGet() {
            await Resource.Get("recp_test_123");
            AssertRequest("GET", "https://api.omise.co/recipients/recp_test_123");
        }

        [Test]
        public async void TestCreate() {
            var request = new CreateRecipientRequest
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                BankAccount = new BankAccount
                {
                    Brand = "KBank",
                    Number = "1234-567-89-0",
                }
            };

            await Resource.Create(request);
            AssertRequest("POST", "https://api.omise.co/recipients");
        }

        [Test]
        public async void TestUpdate() {
            var request = new UpdateRecipientRequest
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                BankAccount = new BankAccount
                {
                    Brand = "KBank",
                    Number = "1234-567-89-0",
                }
            };

            await Resource.Update("recp_test_123", request);
            AssertRequest("PATCH", "https://api.omise.co/recipients/recp_test_123");
        }

        [Test]
        public async void TestDestroy() {
            await Resource.Destroy("recp_test_123");
            AssertRequest("DELETE", "https://api.omise.co/recipients/recp_test_123");
        }
    }
}

