using System;
using NUnit.Framework;

namespace Omise.Tests
{
    [TestFixture]
    public class EndpointTest : OmiseTest
    {
        [Test]
        public void TestCtor()
        {
            var apiPrefix = "https://omise.example.com";
            Assert.Throws<ArgumentNullException>(() => new Endpoint(null));

            var keySelector = Credentials.UseSecretKey;
            var ep = new Endpoint(apiPrefix, null); // default to secret key
            Assert.AreEqual(apiPrefix, ep.ApiPrefix);
            Assert.AreEqual(keySelector, ep.KeySelector);

            keySelector = Credentials.UsePublicKey;
            ep = new Endpoint(apiPrefix, keySelector);
            Assert.AreEqual(keySelector, ep.KeySelector);
        }

        [Test]
        public void TestBuiltinEndpoint()
        {
            Assert.AreEqual(Endpoint.Api.KeySelector, Credentials.UseSecretKey);
            Assert.AreEqual(Endpoint.Vault.KeySelector, Credentials.UsePublicKey);
        }
    }
}

