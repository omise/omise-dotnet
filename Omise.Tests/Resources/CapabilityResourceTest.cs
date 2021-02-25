using NUnit.Framework;
using Omise.Resources;
using System.Linq;
using System.Threading.Tasks;

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

            Assert.True(capability.ZeroInterestInstallments);
            Assert.That(capability.Banks, Does.Contain("kbank"));

            var paymentMethod = capability.PaymentBackends.Find(P => P.Keys.ElementAt(0) == "fpx");

            Assert.AreEqual("fpx", paymentMethod.Keys.ElementAt(0));
            Assert.That(paymentMethod.Values.ElementAt(0).Currencies, Does.Contain("myr"));
        }

        protected override CapabilityResource BuildResource(IRequester requester)
        {
            return new CapabilityResource(requester);
        }
    }
}
