using System.Threading.Tasks;
using NUnit.Framework;
using Omise.Models;
using Omise.Resources;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class DisputeResourceTest : ResourceTest<DisputeResource> {
        const string DisputeId = "dspt_test_5089off452g5m5te7xs";

        [Test]
        public async Task TestGetList() {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/disputes");
        }

        [Test]
        public async Task TestGetListByStatus() {
            await Resource.OpenDisputes.GetList();
            AssertRequest("GET", "https://api.omise.co/disputes/open");
            await Resource.PendingDisputes.GetList();
            AssertRequest("GET", "https://api.omise.co/disputes/pending");
            await Resource.ClosedDisputes.GetList();
            AssertRequest("GET", "https://api.omise.co/disputes/closed");
        }

        [Test]
        public async Task TestGet() {
            await Resource.Get(DisputeId);
            AssertRequest("GET", "https://api.omise.co/disputes/{0}", DisputeId);
        }

        [Test]
        public async Task TestUpdate() {
            await Resource.Update(DisputeId, BuildUpdateRequest());
            AssertRequest("PATCH", "https://api.omise.co/disputes/{0}", DisputeId);
        }

        [Test]
        public void TestUpdateDisputeRequest() {
            AssertSerializedRequest(BuildUpdateRequest(),
                "message=Hello%2C+This+is+definitely+not+ours."
            );
        }

        [Test]
        public async Task TestFixturesGetList() {
            var list = await Fixtures.GetList();
            Assert.AreEqual(1, list.Count);

            var dispute = list[0];
            Assert.AreEqual(DisputeId, dispute.Id);
            Assert.AreEqual(100000, dispute.Amount);
        }

        [Test]
        public async Task TestFixturesGet() {
            var dispute = await Fixtures.Get(DisputeId);
            Assert.AreEqual(DisputeId, dispute.Id);
            Assert.AreEqual(100000, dispute.Amount);
        }

        [Test]
        public async Task TestFixturesUpdate() {
            var dispute = await Fixtures.Update(DisputeId, new UpdateDisputeRequest());
            Assert.AreEqual(DisputeId, dispute.Id);
            Assert.AreEqual("Your dispute message", dispute.Message);
        }

        protected UpdateDisputeRequest BuildUpdateRequest() {
            return new UpdateDisputeRequest {
                Message = "Hello, This is definitely not ours.",
            };
        }

        protected override DisputeResource BuildResource(IRequester requester) {
            return new DisputeResource(requester);
        }
    }
}

