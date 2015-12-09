using System;
using NUnit.Framework;
using Omise.Resources;
using Omise.Models;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Schema;
using Omise.Tests.Util;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class ChargeResourceTest : ResourceTest<ChargeResource> {
        [Test]
        public async void TestGetList() {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/charges");
        }

        [Test]
        public async void TestGet() {
            await Resource.Get("xyz");
            AssertRequest("GET", "https://api.omise.co/charges/xyz");
        }

        [Test]
        public async void TestCreate() {
            await Resource.Create(BuildCreateRequest());
            AssertRequest("POST", "https://api.omise.co/charges");
        }

        [Test]
        public async void TestUpdate() {
            await Resource.Update("chrg_test_123", BuildUpdateRequest());
            AssertRequest("PATCH", "https://api.omise.co/charges/chrg_test_123");
        }

        [Test]
        public async void TestCapture() {
            await Resource.Capture("chrg_test_123");
            AssertRequest("POST", "https://api.omise.co/charges/chrg_test_123/capture");
        }

        [Test]
        public void TestCreateChargeRequest() {
            AssertSerializedRequest(BuildCreateRequest(),
                "customer=Omise%20Co.%2C%20Ltd.&" +
                "card=card_test_123&" +
                "amount=244884&" +
                "currency=thb&" +
                "description=Test%20Charge&" +
                "capture=false&" +
                "return_uri=asdf"
            );
        }

        [Test]
        public void TestUpdateChargeRequest() {
            AssertSerializedRequest(BuildUpdateRequest(),
                "description=Charge%20was%20for%20testing."
            );
        }

        protected CreateChargeRequest BuildCreateRequest() {
            return new CreateChargeRequest
            {
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
            return new UpdateChargeRequest
            {
                Description = "Charge was for testing."
            };
        }

        protected override ChargeResource BuildResource(IRequester requester) {
            return new ChargeResource(requester);
        }
    }
}

