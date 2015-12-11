using System;
using NUnit.Framework;
using Omise.Resources;
using Omise.Models;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class RefundResourceTest : ResourceTest<RefundResource> {
        const string ChargeId = "chrg_test_4yq7duw15p9hdrjp8oq";
        const string RefundId = "rfnd_test_4yqmv79ahghsiz23y3c";

        [Test]
        public async void TestGetList() {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/charges/{0}/refunds", ChargeId);
        }

        [Test]
        public async void TestGet() {
            await Resource.Get(RefundId);
            AssertRequest("GET", "https://api.omise.co/charges/{0}/refunds/{1}", ChargeId, RefundId);
        }

        [Test]
        public async void TestCreate() {
            await Resource.Create(BuildCreateRequest());
            AssertRequest("POST", "https://api.omise.co/charges/{0}/refunds", ChargeId);
        }

        [Test]
        public void TestCreateRefundRequest() {
            AssertSerializedRequest(BuildCreateRequest(),
                "amount=300000"
            );
        }

        [Test]
        public async void TestFixturesGetList() {
            var list = await Fixtures.GetList();
            Assert.AreEqual(1, list.Count);

            var refund = list[0];
            Assert.AreEqual(RefundId, refund.Id);
            Assert.AreEqual(10000, refund.Amount);
        }

        [Test]
        public async void TestFixturesGet() {
            var refund = await Fixtures.Get(RefundId);
            Assert.AreEqual(RefundId, refund.Id);
            Assert.AreEqual(10000, refund.Amount);
        }

        [Test]
        public async void TestFixturesCreate() {
            var refund = await Fixtures.Create(new CreateRefundRequest());
            Assert.AreEqual(RefundId, refund.Id);
            Assert.AreEqual(10000, refund.Amount);
        }

        protected CreateRefundRequest BuildCreateRequest() {
            return new CreateRefundRequest { Amount = 300000 };
        }

        protected override RefundResource BuildResource(IRequester requester) {
            return new RefundResource(requester, ChargeId);
        }
    }
}

