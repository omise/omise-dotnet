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
            var request = new UpdateDisputeRequest
            {
                Message = "Hello, This is definitely not ours.",
            };
            
            await Resource.Update("dspt_test_123", request);
            AssertRequest("PATCH", "https://api.omise.co/disputes/dspt_test_123");
        }

        protected override DisputeResource BuildResource(IRequester requester) {
            return new DisputeResource(requester);
        }
    }
}

