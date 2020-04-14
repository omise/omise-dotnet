using System.Threading.Tasks;
using NUnit.Framework;
using Omise.Resources;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class CapabilityResourceTest : ResourceTest<CapabilityResource>
    {
        [Test]
        public async Task TestGet()
        {
            await Resource.Get();
            AssertRequest("GET", "https://api.omise.co/capability");
        }

        [Test]
        public async Task TestFixturesGet()
        {
            var capability = await Fixtures.Get();
            Assert.AreEqual("TH", capability.Country);
            Assert.True(capability.ZeroInterestInstallments);
        }

        protected override CapabilityResource BuildResource(IRequester requester)
        {
            return new CapabilityResource(requester);
        }
    }
}

