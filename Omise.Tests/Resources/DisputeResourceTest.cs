using System;
using NUnit.Framework;
using Omise.Resources;
using Newtonsoft.Json.Schema;
using Omise.Models;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class DisputeResourceTest : ResourceTest<DisputeResource> {
        [Test]
        public async void TestGetList() {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/disputes");
        }

        [Test]
        public async void TestGetListByStatus() {
            await Resource.OpenDisputes.GetList();
            AssertRequest("GET", "https://api.omise.co/disputes/open");
            await Resource.PendingDisputes.GetList();
            AssertRequest("GET", "https://api.omise.co/disputes/pending");
            await Resource.ClosedDisputes.GetList();
            AssertRequest("GET", "https://api.omise.co/disputes/closed");
        }

        [Test]
        public async void TestGet() {
            await Resource.Get("dspt_test_123");
            AssertRequest("GET", "https://api.omise.co/disputes/dspt_test_123");
        }

        [Test]
        public async void TestUpdate() {
            await Resource.Update("dspt_test_123", BuildUpdateRequest());
            AssertRequest("PATCH", "https://api.omise.co/disputes/dspt_test_123");
        }

        [Test]
        public void TestUpdateDisputeRequest() {
            AssertSerializedRequest(BuildUpdateRequest(),
                "message=Hello%2C%20This%20is%20definitely%20not%20ours."
            );
        }

        protected UpdateDisputeRequest BuildUpdateRequest() {
            return new UpdateDisputeRequest
            {
                Message = "Hello, This is definitely not ours.",
            };
        }

        protected override DisputeResource BuildResource(IRequester requester) {
            return new DisputeResource(requester);
        }
    }
}

