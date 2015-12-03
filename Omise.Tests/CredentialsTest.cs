using System;
using NUnit.Framework;

namespace Omise.Tests {
    [TestFixture]
    public class CredentialsTest : OmiseTest {
        [Test]
        public void TestCtor() {
            var pkey = "pkey_test_123";
            var skey = "skey_test_123";

            Assert.Throws<ArgumentException>(() => new Credentials());
            Assert.DoesNotThrow(() => new Credentials(skey: skey));

            var creds = new Credentials(pkey, skey);
            Assert.AreEqual(pkey, creds.PublicKey.ToString());
            Assert.AreEqual(skey, creds.SecretKey.ToString());
        }
    }
}

