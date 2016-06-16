using System;
using NUnit.Framework;

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
        public void TestAPIVersion() {
            var client = new Client("pkey_test_123", "skey_test_123");
            client.APIVersion = "new-shiny-version";
            Assert.AreEqual("new-shiny-version", client.APIVersion);
            Assert.AreEqual("new-shiny-version", ((Requester)client.Requester).APIVersion);
        }

        [Test]
        public void TestResources() {
            var client = new Client(DummyCredentials);
            var resources = new object[]
            {
                client.Account,
                client.Balance,
                client.Cards,
                client.Charges,
                client.Customers,
                client.Disputes,
                client.Events,
                client.Recipients,
                client.Refunds,
                client.Tokens,
                client.Transactions,
                client.Transfers,
            };

            foreach (var resource in resources) {
                Assert.IsNotNull(resource);
            }

            var cards = client.Cards.ByCustomer("cust_test_123");
            Assert.IsNotNull(cards);
            var refunds = client.Refunds.ByCharge("chrg_test_123");
            Assert.IsNotNull(refunds);
        }
    }
}

