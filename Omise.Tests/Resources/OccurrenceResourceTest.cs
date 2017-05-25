using System;
using Omise.Resources;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class OccurrenceResourceTest : ResourceTest<OccurrenceResource>
    {
        const string OccurrenceId = "occu_test_57ze0f4s494dm0n0o09";

        [Test]
        public async Task TestGet()
        {
            await Resource.Get(OccurrenceId);
            AssertRequest("GET", $"https://api.omise.co/occurrences/{OccurrenceId}");
        }

        protected override OccurrenceResource BuildResource(IRequester requester)
        {
            return new OccurrenceResource(requester);
        }
    }
}
