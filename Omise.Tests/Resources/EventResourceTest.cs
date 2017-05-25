using System.Threading.Tasks;
using NUnit.Framework;
using Omise.Resources;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class EventResourceTest : ResourceTest<EventResource>
    {
        const string EventId = "evnt_test_526yctupnje5mbldskd";

        [Test]
        public async Task TestGetList()
        {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/events");
        }

        [Test]
        public async Task TestGet()
        {
            await Resource.Get(EventId);
            AssertRequest("GET", "https://api.omise.co/events/{0}", EventId);
        }

        [Test]
        public async Task TestFixturesGetList()
        {
            var list = await Fixtures.GetList();
            Assert.AreEqual(20, list.Count);

            var ev = list[0];
            Assert.AreEqual("evnt_test_5232t5tlhjwh7nbi14g", ev.Id);
            Assert.AreEqual("customer.create", ev.Key);
        }

        [Test]
        public async Task TestFixturesGet()
        {
            var ev = await Fixtures.Get(EventId);
            Assert.AreEqual(EventId, ev.Id);
            Assert.AreEqual("transfer.destroy", ev.Key);
        }

        protected override EventResource BuildResource(IRequester requester)
        {
            return new EventResource(requester);
        }
    }
}

