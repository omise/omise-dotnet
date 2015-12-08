using System;
using Omise.Resources;
using NUnit.Framework;
using Omise.Tests.Resources;
using Omise.Models;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class TransferResourceTest : ResourceTest<TransferResource> {
        [Test]
        public async void TestGetList() {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/transfers");
        }

        [Test]
        public async void TestGet() {
            await Resource.Get("trsf_test_123");
            AssertRequest("GET", "https://api.omise.co/transfers/trsf_test_123");
        }

        [Test]
        public async void TestCreate() {
            var request = new CreateTransferRequest
            {
                Recipient = "recp_test_123",
                Amount = 300000,
            };

            await Resource.Create(request);
            AssertRequest("POST", "https://api.omise.co/transfers");
        }

        [Test]
        public async void TestUpdate() {
            var request = new UpdateTransferRequest { Amount = 24488442 };
            await Resource.Update("trsf_test_123", request);
            AssertRequest("PATCH", "https://api.omise.co/transfers/trsf_test_123");
        }

        [Test]
        public async void TestDestroy() {
            await Resource.Destroy("trsf_test_123");
            AssertRequest("DELETE", "https://api.omise.co/transfers/trsf_test_123");
        }

        protected override TransferResource BuildResource(IRequester requester) {
            return new TransferResource(requester);
        }
    }
}

