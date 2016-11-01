using System.Threading.Tasks;
using NUnit.Framework;
using Omise.Models;
using Omise.Resources;

namespace Omise.Tests.Resources {
    public class LinkResourceTest : ResourceTest<LinkResource> {
        const string LinkId = "link_test_55utt7gr1o2ddl11en7";

        [Test]
        public async Task TestGetList() {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/links");
        }

        [Test]
        public async Task TestGet() {
            await Resource.Get(LinkId);
            AssertRequest("GET", "https://api.omise.co/links/{0}", LinkId);
        }

        [Test]
        public async Task TestCreate() {
            await Resource.Create(new CreateLinkRequest());
            AssertRequest("POST", "https://api.omise.co/links");
        }

        [Test]
        public void TestCreateLinkRequest() {
            AssertSerializedRequest(BuildCreateRequest(),
                "amount=2000&" +
                "currency=thb&" +
                "title=Test+Link&" +
                "description=Hello+World&" +
                "multiple=true"
            );
        }

        protected CreateLinkRequest BuildCreateRequest() {
            return new CreateLinkRequest {
                Amount = 2000,
                Currency = "thb",
                Title = "Test Link",
                Description = "Hello World",
                Multiple = true
            };
        }

        protected override LinkResource BuildResource(IRequester requester) {
            return new LinkResource(requester);
        }
    }
}
