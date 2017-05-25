using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Omise.Resources;
using System.Threading.Tasks;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class ForexResourceTest : ResourceTest<ForexResource>
    {
        [Test]
        public async Task TestGet()
        {
            await Resource.Get("thb");
            AssertRequest("GET", "https://api.omise.co/forex/thb");
        }

        protected override ForexResource BuildResource(IRequester requester)
        {
            return new ForexResource(requester);
        }
    }
}
