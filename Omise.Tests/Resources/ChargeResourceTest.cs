using NUnit.Framework;
using Omise.Resources;
using Omise.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class ChargeResourceTest : ResourceTest<ChargeResource>
    {
        const string ChargeId = "chrg_test_4yq7duw15p9hdrjp8oq";

        [Test]
        public async Task TestGetList()
        {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/charges");
        }

        [Test]
        public async Task TestGet()
        {
            await Resource.Get(ChargeId);
            AssertRequest("GET", "https://api.omise.co/charges/{0}", ChargeId);
        }

        [Test]
        public async Task TestCreate()
        {
            await Resource.Create(new CreateChargeRequest());
            AssertRequest("POST", "https://api.omise.co/charges");
        }
        
        [Test]
        public async Task TestCreateWithHeaders()
        {
            var customHeaders = new Dictionary<string, string>
            {
                { "SUB_MERCHANT_ID", "team_123" },
            };
            await Resource.Create(new CreateChargeRequest(),customHeaders);
            AssertRequest("POST", "https://api.omise.co/charges",customHeaders);
        }

        [Test]
        public async Task TestUpdate()
        {
            await Resource.Update(ChargeId, BuildUpdateRequest());
            AssertRequest("PATCH", "https://api.omise.co/charges/{0}", ChargeId);
        }

        [Test]
        public async Task TestCapture()
        {
            await Resource.Capture(ChargeId);
            AssertRequest("POST", "https://api.omise.co/charges/{0}/capture", ChargeId);
        }
        [Test]
        public void TestPartialCaptureRequest()
        {
            AssertSerializedRequest(
                BuildPartialCaptureRequest(),
                @"{""capture_amount"":3000}"
            );
        }
        [Test]
        public async Task TestReverse()
        {
            await Resource.Reverse(ChargeId);
            AssertRequest("POST", "https://api.omise.co/charges/{0}/reverse", ChargeId);
        }

        [Test]
        public async Task TestExpire()
        {
            await Resource.Expire(ChargeId);
            AssertRequest("POST", "https://api.omise.co/charges/{0}/expire", ChargeId);
        }

        [Test]
        public async Task TestSearch()
        {
            var filters = new Dictionary<string, string> { { "amount", "1000.00" } };
            await Resource.Search(ChargeId, filters);
            AssertRequest(
                "GET",
                "https://api.omise.co/search?scope=charge&query={0}&filters%5Bamount%5D={1}",
                ChargeId,
                filters["amount"]
            );
        }

        [Test]
        public void TestCreateChargeRequest()
        {
            AssertSerializedRequest(
                new CreateChargeRequest
            {
                Customer = "Omise Co., Ltd.",
                Card = "card_test_123",
                Amount = 244884,
                Currency = "thb",
                Description = "Test Charge",
                Capture = false,
                ReturnUri = "asdf",
                ExpiresAt = CreateExpiresAt(),
            },
                @"{""customer"":""Omise Co., Ltd.""," +
                @"""card"":""card_test_123""," +
                @"""amount"":244884," +
                @"""currency"":""thb""," +
                @"""description"":""Test Charge""," +
                @"""expires_at"":""2023-08-08T17:00:00Z""," +
                @"""capture"":false," +
                @"""return_uri"":""asdf""}"
            );
        }

        [Test]
        public void TestCreateChargeRequestWithWebHooks()
        {
            AssertSerializedRequest(
               new CreateChargeRequest
            {
                Customer = "Omise Co., Ltd.",
                Card = "card_test_123",
                Amount = 244884,
                Currency = "thb",
                Description = "Test Charge",
                Capture = false,
                ReturnUri = "asdf",
                ExpiresAt = CreateExpiresAt(),
                WebhookEndpoints = new string[] { "https://webhook.site/123" }
            },
                @"{""customer"":""Omise Co., Ltd.""," +
                @"""card"":""card_test_123""," +
                @"""amount"":244884," +
                @"""currency"":""thb""," +
                @"""description"":""Test Charge""," +
                @"""expires_at"":""2023-08-08T17:00:00Z""," +
                @"""capture"":false," +
                @"""webhook_endpoints"":[""https://webhook.site/123""]," +
                @"""return_uri"":""asdf""}"
            );
        }

        [Test]
        public void TestCreateChargeRequestWithPlatFormFee()
        {
            AssertSerializedRequest(
                new CreateChargeRequest
            {
                Customer = "Omise Co., Ltd.",
                Card = "card_test_123",
                Amount = 244884,
                Currency = "thb",
                Description = "Test Charge",
                Capture = false,
                ReturnUri = "asdf",
                ExpiresAt = CreateExpiresAt(),
                PlatformFee = new PlatformFeeRequest{ Fixed = 100, Percentage = 1} 
            },
                @"{""customer"":""Omise Co., Ltd.""," +
                @"""card"":""card_test_123""," +
                @"""amount"":244884," +
                @"""currency"":""thb""," +
                @"""description"":""Test Charge""," +
                @"""expires_at"":""2023-08-08T17:00:00Z""," +
                @"""capture"":false," +
                @"""return_uri"":""asdf""," +
                @"""platform_fee"":{""fixed"":100,""percentage"":1}}"
            );
        }

        [Test]
        public void TestPreAuthCreateChargeRequest()
        {
            AssertSerializedRequest(
                new CreateChargeRequest
            {
                Customer = "Omise Co., Ltd.",
                Card = "card_test_123",
                Amount = 244884,
                Currency = "thb",
                Description = "Test Charge",
                AuthorizationType = AuthTypes.PreAuth,
                Capture = false,
                ReturnUri = "asdf",
                ExpiresAt = CreateExpiresAt(),
            },
                @"{""customer"":""Omise Co., Ltd.""," +
                @"""card"":""card_test_123""," +
                @"""amount"":244884," +
                @"""authorization_type"":""pre_auth""," +
                @"""currency"":""thb""," +
                @"""description"":""Test Charge""," +
                @"""expires_at"":""2023-08-08T17:00:00Z""," +
                @"""capture"":false," +
                @"""return_uri"":""asdf""}"
            );
        }

        [Test]
        public void TestUpdateChargeRequest()
        {
            AssertSerializedRequest(
                BuildUpdateRequest(),
                @"{""description"":""Charge was for testing.""}"
            );
        }

        [Test]
        public async Task TestFixturesGetList()
        {
            var list = await Fixtures.GetList();
            Assert.AreEqual(1, list.Count);

            var charge = list[0];
            Assert.AreEqual(ChargeId, charge.Id);
        }

        [Test]
        public async Task TestFixturesGet()
        {
            var charge = await Fixtures.Get(ChargeId);
            Assert.AreEqual(ChargeId, charge.Id);
            Assert.AreEqual(100000, charge.Amount);
        }

        [Test]
        public async Task TestFixturesCreate()
        {
            var charge = await Fixtures.Create(new CreateChargeRequest());
            Assert.AreEqual(ChargeId, charge.Id);
            Assert.AreEqual("Do not retry the transaction with the same card", charge.MerchantAdvice);
            Assert.AreEqual("9003", charge.MerchantAdviceCode);
            Assert.AreEqual(new List<string> { "email", "phone_number" }, charge.Missing3dsFields);
            Assert.AreEqual(100000, charge.Amount);
            Assert.IsInstanceOf(typeof(PaymentSource), charge.Source);
            Assert.IsInstanceOf(typeof(Barcode), charge.Source.ScannableCode);
            Assert.IsInstanceOf(typeof(Document), charge.Source.ScannableCode.Image);
        }

        [Test]
        public async Task TestFixturesUpdate()
        {
            var charge = await Fixtures.Update(ChargeId, new UpdateChargeRequest());
            Assert.AreEqual(ChargeId, charge.Id);
            Assert.AreEqual("Charge for order 3947 (XXL)", charge.Description);
        }

        [Test]
        public async Task TestFixturesSearch()
        {
            var result = await Fixtures.Search(filters: new Dictionary<string, string> {
                { "amount", "4096.69" }
            });

            Assert.That(result.Total, Is.EqualTo(30));
            Assert.That(result.TotalPages, Is.EqualTo(1));
            Assert.That(result[0].Id, Is.EqualTo("chrg_test_558xxh0el72ust8ogda"));
            Assert.That(result[0].Amount, Is.EqualTo(409669));
        }

        protected DateTime CreateExpiresAt()
        {
            TimeZoneInfo thailandZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Bangkok");
            DateTime thailandTime = new DateTime(2023, 8, 9, 0, 0, 0);
            DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(thailandTime, thailandZone);
            return utcTime;
        }

        protected UpdateChargeRequest BuildUpdateRequest()
        {
            return new UpdateChargeRequest
            {
                Description = "Charge was for testing."
            };
        }

        protected override ChargeResource BuildResource(IRequester requester)
        {
            return new ChargeResource(requester);
        }
        protected CaptureChargeRequest BuildPartialCaptureRequest()
        {
            return new CaptureChargeRequest
            {
                CaptureAmount = 3000
            };
        }
    }
}

