using System;
using Omise.Tests.Util;
using System.Threading.Tasks;
using Omise.Resources;
using NUnit.Framework;

namespace Omise.Tests.Resources {
    public abstract class ResourceTest : OmiseTest {
        protected IRequester Requester { get; private set; }

        [SetUp]
        public void Setup() {
            Requester = new MockRequester();
        }

        protected void AssertRequest(string method, string uri) {
            var mockRequester = (MockRequester)Requester;

            var attempt = mockRequester.LastRequest;
            Assert.AreEqual(attempt.Method, method);
            Assert.AreEqual(attempt.Endpoint.ApiPrefix + attempt.Path, uri);
        }
    }
}

