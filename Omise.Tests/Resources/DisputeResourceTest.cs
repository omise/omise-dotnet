using System;
using NUnit.Framework;
using Omise.Resources;
using Newtonsoft.Json.Schema;
using Omise.Models;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class DisputeResourceTest : ResourceTest {
        [Test]
        public async void TestGetList() {
            var resource = new DisputeResource(Requester);
            await resource.GetList();
            AssertRequest("GET", "https://api.omise.co/disputes");
        }

        [Test]
        public async void TestGetListByStatus() {
            var resource = new DisputeResource(Requester);
            await resource.OpenDisputes.GetList();
            AssertRequest("GET", "https://api.omise.co/disputes/open");
            await resource.PendingDisputes.GetList();
            AssertRequest("GET", "https://api.omise.co/disputes/pending");
            await resource.ClosedDisputes.GetList();
            AssertRequest("GET", "https://api.omise.co/disputes/closed");
        }

        [Test]
        public async void TestGet() {
            var resource = new DisputeResource(Requester);
            await resource.Get("dspt_test_123");
            AssertRequest("GET", "https://api.omise.co/disputes/dspt_test_123");
        }

        [Test]
        public async void TestUpdate() {
            var resource = new DisputeResource(Requester);
            var request = new UpdateDisputeRequest
            {
                Message = "Hello, This is definitely not ours.",
            };
            
            await resource.Update("dspt_test_123", request);
            AssertRequest("PATCH", "https://api.omise.co/disputes/dspt_test_123");
        }
    }
}

