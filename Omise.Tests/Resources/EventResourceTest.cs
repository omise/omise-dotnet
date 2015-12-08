using System;
using Omise.Tests.Resources;
using NUnit.Framework;
using Omise.Resources;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class EventResourceTest : ResourceTest {
        [Test]
        public async void TestGetList() {
            var resource = new EventResource(Requester);
            await resource.GetList();
            AssertRequest("GET", "https://api.omise.co/events");
        }

        [Test]
        public async void TestGet() {
            var resource = new EventResource(Requester);
            await resource.Get("evnt_test_123");
            AssertRequest("GET", "https://api.omise.co/events/evnt_test_123");
        }
    }
}

