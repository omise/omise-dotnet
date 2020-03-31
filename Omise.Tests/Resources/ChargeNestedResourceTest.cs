using System;
using Omise.Resources;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace Omise.Tests.Resources
{
    public class ChargeNestedResourceTest : ResourceTest<ChargeResource>
    {
        const string ChargeId = "chrg_test_4yq7duw15p9hdrjp8oq";

        [Test]
        public void TestRefunds()
        {
            Assert.AreEqual($"/charges/{ChargeId}/refunds", Resource.Refunds.BasePath);
            Assert.IsInstanceOf(typeof(ChargeRefundResource), Resource.Refunds);
        }

        [Test]
        public void TestEvents()
        {
            Assert.AreEqual($"/charges/{ChargeId}/events", Resource.Events.BasePath);
            Assert.IsInstanceOf(typeof(ChargeEventResource), Resource.Events);
        }

        protected override ChargeResource BuildResource(IRequester requester)
        {
            return new ChargeResource(requester).Charge(ChargeId);
        }
    }
}
