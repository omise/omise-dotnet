using System;
using Omise.Tests.Util;
using System.Threading.Tasks;
using Omise.Resources;
using NUnit.Framework;

namespace Omise.Tests.Resources {
    public abstract class ResourceTest<TResource> : OmiseTest {
        protected IRequester Requester { get; private set; }
        protected TResource Resource { get; private set; }

        [SetUp]
        public void Setup() {
            Requester = new MockRequester();
            Resource = BuildResource(Requester);
        }

        protected abstract TResource BuildResource(IRequester requester);

        protected void AssertRequest(string method, string uri) {
            var mockRequester = (MockRequester)Requester;

            var attempt = mockRequester.LastRequest;
            Assert.AreEqual(method, attempt.Method, method);
            Assert.AreEqual(uri, attempt.Endpoint.ApiPrefix + attempt.Path);
        }
    }
}

