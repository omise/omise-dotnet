using System;
using Omise;
using Omise.Tests.Util;
using System.Threading.Tasks;
using Omise.Resources;
using NUnit.Framework;
using Omise.Models;
using System.Net.Http;

namespace Omise.Tests.Resources {
    public abstract class ResourceTest<TResource> : OmiseTest {
        protected MockRequester Requester { get; private set; }
        protected TResource Resource { get; private set; }
        protected Serializer Serializer { get; private set; }

        protected TResource Fixtures { get; private set; }

        [SetUp]
        public void Setup() {
            Requester = new MockRequester();
            Resource = BuildResource(Requester);
            Serializer = new Serializer();

            var fixtures = new Requester(DummyCredentials, new FixturesRoundtripper());
            Fixtures = BuildResource(fixtures);
        }

        protected abstract TResource BuildResource(IRequester requester);

        protected void AssertRequest(
            string method,
            string uriFormat,
            params object[] uriArgs
        ) {
            var uri = string.Format(uriFormat, uriArgs);

            var attempt = Requester.LastRequest;
            Assert.AreEqual(method, attempt.Method, method);
            Assert.AreEqual(uri, attempt.Endpoint.ApiPrefix + attempt.Path);
        }

        protected void AssertSerializedRequest<TRequest>(
            TRequest request,
            string serialized
        ) where TRequest: Request {
            var values = Serializer.ExtractFormValues(request);
            var encoded = new FormUrlEncodedContent(values);
            var result = encoded.ReadAsStringAsync().Result;

            Assert.AreEqual(serialized, result);
        }
    }
}
