using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Omise.Models;
using Omise.Resources;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class TransferResourceTest : ResourceTest<TransferResource>
    {
        const string TransferId = "trsf_test_4yqacz8t3cbipcj766u";

        [Test]
        public async Task TestGetList()
        {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/transfers");
        }

        [Test]
        public async Task TestGet()
        {
            await Resource.Get(TransferId);
            AssertRequest("GET", "https://api.omise.co/transfers/{0}", TransferId);
        }

        [Test]
        public async Task TestCreate()
        {
            await Resource.Create(BuildCreateRequest());
            AssertRequest("POST", "https://api.omise.co/transfers");
        }

        [Test]
        public async Task TestUpdate()
        {
            await Resource.Update(TransferId, BuildUpdateRequest());
            AssertRequest("PATCH", "https://api.omise.co/transfers/{0}", TransferId);
        }

        [Test]
        public async Task TestDestroy()
        {
            await Resource.Destroy(TransferId);
            AssertRequest("DELETE", "https://api.omise.co/transfers/{0}", TransferId);
        }

        [Test]
        public void TestCreateTransferRequest()
        {
            AssertSerializedRequest(
                BuildCreateRequest(),
                new Dictionary<string, object>
                {
                    { "amount", 300000 },
                    { "recipient", "recp_test_123" },
                    { "fail_fast", false },
                    { "metadata", new Dictionary<string, object>
                        {
                            { "color", "red"},
                        }
                    }
                }
            );
        }

        [Test]
        public void TestUpdateTransferRequest()
        {
            AssertSerializedRequest(
                BuildUpdateRequest(),
                new Dictionary<string, object>
                {
                    { "amount", 24488442 },
                    { "metadata", new Dictionary<string, object>
                        {
                            { "color", "red" }
                        }
                    }
                }
            );
        }

        [Test]
        public async Task TestFixturesGetList()
        {
            var list = await Fixtures.GetList();
            Assert.AreEqual(2, list.Count);

            var transfer = list[0];
            Assert.AreEqual(TransferId, transfer.Id);
            Assert.AreEqual(192188, transfer.Amount);
        }

        [Test]
        public async Task TestFixturesGet()
        {
            var transfer = await Fixtures.Get(TransferId);
            Assert.AreEqual(TransferId, transfer.Id);
            Assert.AreEqual(192188, transfer.Amount);
        }

        [Test]
        public async Task TestFixturesCreate()
        {
            var transfer = await Fixtures.Create(new CreateTransferParams());
            Assert.AreEqual(TransferId, transfer.Id);
            Assert.AreEqual(192188, transfer.Amount);
        }

        [Test]
        public async Task TestFixturesUpdate()
        {
            var transfer = await Fixtures.Update(TransferId, new UpdateTransferParams());
            Assert.AreEqual(TransferId, transfer.Id);
            Assert.AreEqual(192189, transfer.Amount);
        }

        [Test]
        public async Task TestFixturesDestroy()
        {
            var transfer = await Fixtures.Destroy(TransferId);
            Assert.AreEqual(TransferId, transfer.Id);
            Assert.IsTrue(transfer.Deleted);
        }

        protected CreateTransferParams BuildCreateRequest()
        {
            return new CreateTransferParams
            {
                Recipient = "recp_test_123",
                Amount = 300000,
                Metadata = new Dictionary<string, object> { { "color", "red" } }
            };
        }

        protected UpdateTransferParams BuildUpdateRequest()
        {
            return new UpdateTransferParams
            { 
                Amount = 24488442,
                Metadata = new Dictionary<string, object> { { "color", "red" } }
            };
        }

        protected override TransferResource BuildResource(IRequester requester)
        {
            return new TransferResource(requester);
        }
    }
}

