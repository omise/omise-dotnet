using System;
using Omise.Tests.Util;
using System.Threading.Tasks;
using Omise.Resources;
using NUnit.Framework;
using Omise.Models;

namespace Omise.Tests.Resources {
    public abstract class ResourceTest<TResource> : OmiseTest {
        protected MockRequester Requester { get; private set; }
        protected TResource Resource { get; private set; }
        protected Serializer Serializer { get; private set; }

        [SetUp]
        public void Setup() {
            Requester = new MockRequester();
            Resource = BuildResource(Requester);
            Serializer = new Serializer();
        }

        protected abstract TResource BuildResource(IRequester requester);

        protected void AssertRequest(string method, string uri) {
            var attempt = Requester.LastRequest;
            Assert.AreEqual(method, attempt.Method, method);
            Assert.AreEqual(uri, attempt.Endpoint.ApiPrefix + attempt.Path);
        }

        protected void AssertSerializedRequest<TRequest>(
            TRequest request,
            string serialized
        ) where TRequest: Request {
            var stream = new StringMemoryStream();
            Serializer.FormSerialize(stream, request);
            Assert.AreEqual(serialized, stream.ToDecodedString());
        }
    }
}

