using System;
using Omise.Tests.Util;
using System.Threading.Tasks;
using Omise.Resources;
using NUnit.Framework;

namespace Omise.Tests.Resources {
    public abstract class ResourceTest : OmiseTest {
        protected MockRequester BuildRequester(object responseObject = null) {
            var requester = new MockRequester();
            requester.ResponseObject = responseObject;
            return requester;
        }

        protected void AssertRequest(MockRequester requester, string method, string uri) {
            var attempt = requester.LastRequest;
            Assert.AreEqual(attempt.Method, method);
            Assert.AreEqual(attempt.Endpoint.ApiPrefix + attempt.Path, uri);
        }
    }
}

