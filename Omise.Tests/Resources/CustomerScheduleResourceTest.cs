using System;
using Omise.Resources;
using System.Diagnostics.Tracing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class CustomerScheduleResourceTest : ResourceTest<CustomerScheduleResource>
    {
        const string CustomerId = "cust_test_4yq6txdpfadhbaqnwp3";

        [Test]
        public async Task TestGetList()
        {
            await Resource.GetList();
            AssertRequest("GET", $"https://api.omise.co/customers/{CustomerId}/schedules");
        }

        protected override CustomerScheduleResource BuildResource(IRequester requester)
        {
            return new CustomerScheduleResource(requester, CustomerId);
        }
    }
}
