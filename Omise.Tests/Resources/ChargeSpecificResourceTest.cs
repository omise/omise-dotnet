using System;
using Omise.Resources;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace Omise.Tests.Resources
{
    public class ChargeSpecificResourceTest : ResourceTest<ChargeSpecificResource>
    {
        const string ChargeId = "chrg_test_4yq7duw15p9hdrjp8oq";

        [Test]
        public void TestBasePath()
        {
            Assert.IsTrue(Resource.BasePath.Contains(ChargeId));
        }

        [Test]
        public void TestRefunds()
        {
            Assert.IsNotNull(Resource.Refunds);
        }

        protected override ChargeSpecificResource BuildResource(IRequester requester)
        {
            return new ChargeSpecificResource(requester, ChargeId);
        }
    }
}
