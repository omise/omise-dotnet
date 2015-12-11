using System;
using Omise.Tests.Resources;
using NUnit.Framework;
using Omise.Resources;
using Omise.Models;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class EventResourceTest : ResourceTest<EventResource> {
        const string EventId = "evnt_test_526yctupnje5mbldskd";
            
        [Test]
        public async void TestGetList() {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/events");
        }

        [Test]
        public async void TestGet() {
            await Resource.Get(EventId);
            AssertRequest("GET", "https://api.omise.co/events/{0}", EventId);
        }

        [Test]
        public async void TestFixturesGetList() {
            var list = await Fixtures.GetList();
            Assert.AreEqual(20, list.Count);

            var ev = list[0];
            Assert.AreEqual("evnt_test_5232t5tlhjwh7nbi14g", ev.Id);
            Assert.AreEqual("customer.create", ev.Key);
        }

        [Test]
        public async void TestFixturesGet() {
            var ev = await Fixtures.Get(EventId);
            Assert.AreEqual(EventId, ev.Id);
            Assert.AreEqual("transfer.destroy", ev.Key);
        }

        protected override EventResource BuildResource(IRequester requester) {
            return new EventResource(requester);
        }
    }
}

