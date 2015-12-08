using System;
using NUnit.Framework;
using Omise.Models;

namespace Omise.Tests {
    [TestFixture]
    public class ClientTest : OmiseTest {
        [Test]
        public void TestCtor() {
            var pkey = "pkey_test_123";
            var skey = "skey_test_123";

            Assert.Throws<ArgumentException>(() => new Client(null, null));
            Assert.DoesNotThrow(() => new Client(pkey, null));
            Assert.DoesNotThrow(() => new Client(null, skey));
            Assert.DoesNotThrow(() => new Client(pkey, skey));

            var creds = DummyCredentials;
            Assert.Throws<ArgumentNullException>(() => new Client(credentials: null));
            Assert.DoesNotThrow(() => new Client(creds));
        }

        [Test]
        public void TestResources() {
            var client = new Client(DummyCredentials);
            var resources = new object[]
            {
                client.Account,
                client.Balance,
                client.Charges,
                client.Customers,
                client.Disputes,
                client.Events,
                client.Recipients,
                client.Tokens,
                client.Transactions,
                client.Transfers,
            };

            foreach (var resource in resources) {
                Assert.IsNotNull(resource);
            }
        }
    }
}

