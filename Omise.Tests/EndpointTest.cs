using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Omise.Tests {
    [TestFixture]
    public class EndpointTest : OmiseTest {
        [Test]
        public void TestCtor() {
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
    }
}

