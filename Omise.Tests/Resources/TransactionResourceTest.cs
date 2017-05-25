using System.Threading.Tasks;
using NUnit.Framework;
using Omise.Resources;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class TransactionResourceTest : ResourceTest<TransactionResource>
    {
        const string TransactionId = "trxn_test_4yq7duwb9jts1vxgqua";

        [Test]
        public async Task TestGetList()
        {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/transactions");
        }

        [Test]
        public async Task TestGet()
        {
            await Resource.Get(TransactionId);
            AssertRequest("GET", "https://api.omise.co/transactions/{0}", TransactionId);
        }

        [Test]
        public async Task TestFixturesGetList()
        {
            var list = await Fixtures.GetList();
            Assert.AreEqual(2, list.Count);

            var tx = list[0];
            Assert.AreEqual(TransactionId, tx.Id);
            Assert.AreEqual(96094, tx.Amount);
        }

        [Test]
        public async Task TestFixturesGet()
        {
            var tx = await Fixtures.Get(TransactionId);
            Assert.AreEqual(TransactionId, tx.Id);
            Assert.AreEqual(96094, tx.Amount);
        }

        protected override TransactionResource BuildResource(IRequester requester)
        {
            return new TransactionResource(requester);
        }
    }
}

