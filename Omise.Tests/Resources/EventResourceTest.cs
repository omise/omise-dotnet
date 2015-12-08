using System;
using Omise.Tests.Resources;
using NUnit.Framework;
using Omise.Resources;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class EventResourceTest : ResourceTest<EventResource> {
        [Test]
        public async void TestGetList() {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/events");
        }

        [Test]
        public async void TestGet() {
            await Resource.Get("evnt_test_123");
            AssertRequest("GET", "https://api.omise.co/events/evnt_test_123");
        }

        protected override EventResource BuildResource(IRequester requester) {
            return new EventResource(requester);
        }
    }
}

