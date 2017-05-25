using System;
using Omise.Resources;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class RefundResourceTest : ResourceTest<RefundResource>
    {
        const string RefundId = "rfnd_test_56gs5h8w22wcmhmg92c";

        [Test]
        public async Task TestGetList()
        {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/refunds");
        }

        [Test]
        public async Task TestSearch()
        {
            await Resource.Search(RefundId);
            AssertRequest("GET", $"https://api.omise.co/search?scope=refund&query={RefundId}");
        }

        protected override RefundResource BuildResource(IRequester requester)
        {
            return new RefundResource(requester);
        }
    }
}
