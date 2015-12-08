using System;
using Omise.Resources;
using NUnit.Framework;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class TransactionResourceTest : ResourceTest<TransactionResource> {
        [Test]
        public async void TestGetList() {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/transactions");
        }

        [Test]
        public async void TestGet() {
            await Resource.Get("trxn_test_123");
            AssertRequest("GET", "https://api.omise.co/transactions/trxn_test_123");
        }

        protected override TransactionResource BuildResource(IRequester requester) {
            return new TransactionResource(requester);
        }
    }
}

