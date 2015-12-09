using System;
using NUnit.Framework;
using Omise.Resources;
using Omise.Models;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class RefundResourceTest : ResourceTest<RefundResource> {
        [Test]
        public async void TestGetList() {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/charges/chrg_test_123/refunds");
        }

        [Test]
        public async void TestGet() {
            await Resource.Get("rfnd_test_123");
            AssertRequest("GET", "https://api.omise.co/charges/chrg_test_123/refunds/rfnd_test_123");
        }

        [Test]
        public async void TestCreate() {
            await Resource.Create(BuildCreateRequest());
            AssertRequest("POST", "https://api.omise.co/charges/chrg_test_123/refunds");
        }

        [Test]
        public void TestCreateRefundRequest() {
            AssertSerializedRequest(BuildCreateRequest(),
                "amount=300000"
            );
        }

        protected CreateRefundRequest BuildCreateRequest() {
            return new CreateRefundRequest { Amount = 300000 };
        }

        protected override RefundResource BuildResource(IRequester requester) {
            return new RefundResource(requester, "chrg_test_123");
        }
    }
}

