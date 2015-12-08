using System;
using Omise.Resources;
using Omise.Models;
using NUnit.Framework;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class ListableTest : ResourceTest<DummyListableResource> {
        [Test]
        public async void TestGetList() {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/dummy");
        }

        [Test]
        public async void TestGetListWithOptions() {
            await Resource.GetList(
                offset: 2,
                limit: 3,
                from: new DateTime(2012, 12, 25),
                to: new DateTime(2013, 1, 1),
                ordering: Ordering.ReverseChronological
            );
            AssertRequest("GET", "https://api.omise.co/dummy?" +
                "offset=2&" +
                "limit=3&" +
                "from=2012-12-25T00%3A00%3A00Z&" +
                "to=2013-01-01T00%3A00%3A00Z&" +
                "ordering=reverse_chronological");
        }

        protected override DummyListableResource BuildResource(IRequester requester) {
            return new DummyListableResource(requester);
        }
    }

    public class DummyListableResource : BaseResource<ModelBase>, IListable<ModelBase> {
        public DummyListableResource(IRequester requester)
            : base(requester, Endpoint.Api, "/dummy") {
        }
    }
}

