using System.Threading.Tasks;
using NUnit.Framework;
using Omise.Models;
using Omise.Resources;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class ChargeSpecificRefundResourceTest : ResourceTest<ChargeSpecificRefundResource>
    {
        const string ChargeId = "chrg_test_4yq7duw15p9hdrjp8oq";
        const string RefundId = "rfnd_test_4yqmv79ahghsiz23y3c";

        [Test]
        public async Task TestGetList()
        {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/charges/{0}/refunds", ChargeId);
        }

        [Test]
        public async Task TestGet()
        {
            await Resource.Get(RefundId);
            AssertRequest("GET", "https://api.omise.co/charges/{0}/refunds/{1}", ChargeId, RefundId);
        }

        [Test]
        public async Task TestCreate()
        {
            await Resource.Create(BuildCreateRequest());
            AssertRequest("POST", "https://api.omise.co/charges/{0}/refunds", ChargeId);
        }

        [Test]
        public void TestCreateRefundRequest()
        {
            AssertSerializedRequest(
                BuildCreateRequest(),
                @"{""amount"":300000," +
                @"""void"":false}"
            );
        }

        [Test]
        public async Task TestFixturesGetList()
        {
            var list = await Fixtures.GetList();
            Assert.AreEqual(1, list.Count);

            var refund = list[0];
            Assert.AreEqual(RefundId, refund.Id);
            Assert.AreEqual(10000, refund.Amount);
        }

        [Test]
        public async Task TestFixturesGet()
        {
            var refund = await Fixtures.Get(RefundId);
            Assert.AreEqual(RefundId, refund.Id);
            Assert.AreEqual(10000, refund.Amount);
        }

        [Test]
        public async Task TestFixturesCreate()
        {
            var refund = await Fixtures.Create(new CreateRefundRequest());
            Assert.AreEqual(RefundId, refund.Id);
            Assert.AreEqual(10000, refund.Amount);
        }

        protected CreateRefundRequest BuildCreateRequest()
        {
            return new CreateRefundRequest { Amount = 300000 };
        }

        protected override ChargeSpecificRefundResource BuildResource(IRequester requester)
        {
            return new ChargeSpecificRefundResource(requester, ChargeId);
        }
    }
}

