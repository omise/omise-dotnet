using NUnit.Framework;
using Omise.Resources;
using Omise.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class ChargeResourceTest : ResourceTest<ChargeResource> {
        const string ChargeId = "chrg_test_4yq7duw15p9hdrjp8oq";

        [Test]
        public async Task TestGetList() {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/charges");
        }

        [Test]
        public async Task TestGet() {
            await Resource.Get(ChargeId);
            AssertRequest("GET", "https://api.omise.co/charges/{0}", ChargeId);
        }

        [Test]
        public async Task TestCreate() {
            await Resource.Create(BuildCreateRequest());
            AssertRequest("POST", "https://api.omise.co/charges");
        }

        [Test]
        public async Task TestUpdate() {
            await Resource.Update(ChargeId, BuildUpdateRequest());
            AssertRequest("PATCH", "https://api.omise.co/charges/{0}", ChargeId);
        }

        [Test]
        public async Task TestCapture() {
            await Resource.Capture(ChargeId);
            AssertRequest("POST", "https://api.omise.co/charges/{0}/capture", ChargeId);
        }

        [Test]
        public async Task TestReverse() {
            await Resource.Reverse(ChargeId);
            AssertRequest("POST", "https://api.omise.co/charges/{0}/reverse", ChargeId);
        }

        [Test]
        public async Task TestSearch() {
            var filters = new Dictionary<string, string> { { "amount", "1000.00" } };
            await Resource.Search(ChargeId, filters);
            AssertRequest(
                "GET",
                "https://api.omise.co/search?scope=charge&query={0}&filters[aaaamount]={1}",
                ChargeId,
                filters["amount"]
            );
        }

        [Test]
        public void TestCreateChargeRequest() {
            AssertSerializedRequest(BuildCreateRequest(),
                "customer=Omise+Co.%2C+Ltd.&" +
                "card=card_test_123&" +
                "amount=244884&" +
                "currency=thb&" +
                "description=Test+Charge&" +
                "capture=false&" +
                "return_uri=asdf"
            );
        }

        [Test]
        public void TestUpdateChargeRequest() {
            AssertSerializedRequest(BuildUpdateRequest(),
                "description=Charge+was+for+testing."
            );
        }

        [Test]
        public async Task TestFixturesGetList() {
            var list = await Fixtures.GetList();
            Assert.AreEqual(1, list.Count);

            var charge = list[0];
            Assert.AreEqual(ChargeId, charge.Id);
        }

        [Test]
        public async Task TestFixturesGet() {
            var charge = await Fixtures.Get(ChargeId);
            Assert.AreEqual(ChargeId, charge.Id);
            Assert.AreEqual(100000, charge.Amount);
        }

        [Test]
        public async Task TestFixturesCreate() {
            var charge = await Fixtures.Create(new CreateChargeRequest());
            Assert.AreEqual(ChargeId, charge.Id);
            Assert.AreEqual(100000, charge.Amount);
        }

        [Test]
        public async Task TestFixturesUpdate() {
            var charge = await Fixtures.Update(ChargeId, new UpdateChargeRequest());
            Assert.AreEqual(ChargeId, charge.Id);
            Assert.AreEqual("Charge for order 3947 (XXL)", charge.Description);
        }

        protected CreateChargeRequest BuildCreateRequest() {
            return new CreateChargeRequest {
                Customer = "Omise Co., Ltd.",
                Card = "card_test_123",
                Amount = 244884,
                Currency = "thb",
                Description = "Test Charge",
                Capture = false,
                ReturnUri = "asdf"
            };
        }

        protected UpdateChargeRequest BuildUpdateRequest() {
            return new UpdateChargeRequest {
                Description = "Charge was for testing."
            };
        }

        protected override ChargeResource BuildResource(IRequester requester) {
            return new ChargeResource(requester);
        }
    }
}

