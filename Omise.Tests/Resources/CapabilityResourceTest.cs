using NUnit.Framework;
using Omise.Resources;
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

            Assert.AreEqual("TH", capability.Country);
            Assert.False(capability.ZeroInterestInstallments);
            Assert.That(capability.Banks, Does.Contain("kbank"));

            var fpx = capability.PaymentMethods.Find(P => P.Name == "fpx");
            var bank = fpx.Banks.Find(B => B.Code == "cimb");

            Assert.AreEqual("fpx", fpx.Name);
            Assert.Null(fpx.InstallmentTerms);

            Assert.AreEqual("CIMB Clicks", bank.Name);
            Assert.True(bank.Active);

        }

        protected override CapabilityResource BuildResource(IRequester requester)
        {
            return new CapabilityResource(requester);
        }
    }
}
