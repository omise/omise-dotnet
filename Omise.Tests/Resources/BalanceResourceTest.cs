using System.Threading.Tasks;
using NUnit.Framework;
using Omise.Resources;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class BalanceResourceTest : ResourceTest<BalanceResource>
    {
        [Test]
        public async Task TestGet()
        {
            await Resource.Get();
            AssertRequest("GET", "https://api.omise.co/balance");
        }

        [Test]
        public async Task TestFixturesGet()
        {
            var balance = await Fixtures.Get();
            Assert.AreEqual(96094, balance.Total);
        }

        protected override BalanceResource BuildResource(IRequester requester)
        {
            return new BalanceResource(requester);
        }
    }
}

