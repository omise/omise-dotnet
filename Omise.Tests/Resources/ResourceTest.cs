using NUnit.Framework;
using Omise.Models;
using Omise.Tests.Util;

namespace Omise.Tests.Resources
{
    public abstract class ResourceTest<TResource> : OmiseTest
    {
        protected MockRequester Requester { get; private set; }
        protected IEnvironment Environment { get; private set; }
        protected TResource Resource { get; private set; }
        protected Serializer Serializer { get; private set; }

        protected TResource Fixtures { get; private set; }

        [SetUp]
        public void Setup()
        {
            Requester = new MockRequester();
            Resource = BuildResource(Requester);
            Serializer = new Serializer();
            Environment = Environments.Production;

            var fixtures = new Requester(
                DummyCredentials,
                Environments.Production,
                new FixturesRoundtripper()
            );
            Fixtures = BuildResource(fixtures);
        }

        protected abstract TResource BuildResource(IRequester requester);

        protected void AssertRequest(
            string method,
            string uriFormat,
            params object[] uriArgs
        )
        {
            var attempt = Requester.LastRequest;

            var uri = string.Format(uriFormat, uriArgs);
            var expectedUri = Environment.ResolveEndpoint(attempt.Endpoint) + attempt.Path;

            Assert.AreEqual(method, attempt.Method);
            Assert.AreEqual(uri, expectedUri);
        }

        protected void AssertSerializedRequest<TRequest>(
            TRequest request,
            string serialized
        ) where TRequest : Request
        {
            using (var ms = new StringMemoryStream())
            {
                Serializer.JsonSerialize(ms, request);
                Assert.AreEqual(serialized, ms.ToDecodedString());
            }
        }
    }
}