using System;
using NUnit.Framework;
using System.Threading.Tasks;
using Omise.Resources;
using Omise.Models;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class SourceResourceTest : ResourceTest<SourceResource>
    {
        const string SourceId = "src_test_no1t4tnemucod0e51mo";

        [Test]
        public async Task TestGet()
        {
            await Resource.Get(SourceId);
            AssertRequest("GET", "https://api.omise.co/sources/{0}", SourceId);
        }

        [Test]
        public async Task TestFixturesGet()
        {
            var source = await Fixtures.Get(SourceId);
            Assert.AreEqual(SourceId, source.Id);
            Assert.IsInstanceOf(typeof(Barcode), source.ScannableCode);
            Assert.IsInstanceOf(typeof(Document), source.ScannableCode.Image);
        }

        protected override SourceResource BuildResource(IRequester requester)
        {
            return new SourceResource(requester);
        }
    }
}
