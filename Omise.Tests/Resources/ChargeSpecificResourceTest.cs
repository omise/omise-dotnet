using System;
using Omise.Resources;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace Omise.Tests.Resources
{
    public class ChargeSpecificResourceTest : ResourceTest<ChargeResource>
    {
        const string ChargeId = "chrg_test_4yq7duw15p9hdrjp8oq";

        [Test]
        public void TestBasePath()
        {
            Assert.IsTrue(Resource.Refunds.BasePath.Contains(ChargeId));
            Assert.IsTrue(Resource.Events.BasePath.Contains(ChargeId));
        }

        [Test]
        public void TestRefunds()
        {
            Assert.IsInstanceOf(typeof(ChargeRefundResource), Resource.Refunds);
        }

        [Test]
        public void TestEvents()
        {
            Assert.IsInstanceOf(typeof(ChargeEventResource), Resource.Events);
        }

        protected override ChargeResource BuildResource(IRequester requester)
        {
            return new ChargeResource(requester).Charge(ChargeId);
        }
    }
}
