using System;
using NUnit.Framework;
using Omise.Resources;
using Omise.Models;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class RefundResourceTest : ResourceTest {
        RefundResource Resource { get; set; }

        [SetUp]
        public void SetupResource() {
            Resource = new RefundResource(Requester, "chrg_test_123");
        }

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
            var request = new CreateRefundRequest { Amount = 300000 };
            await Resource.Create(request);
            AssertRequest("POST", "https://api.omise.co/charges/chrg_test_123/refunds");
        }
    }
}

