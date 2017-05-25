using System;
using Omise.Resources;
using System.Diagnostics.Tracing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class CustomerSpecificScheduleResourceTest : ResourceTest<CustomerSpecificScheduleResource>
    {
        const string CustomerId = "cust_test_4yq6txdpfadhbaqnwp3";
        const string ScheduleId = "card_test_4yq6tuucl9h4erukfl0";

        [Test]
        public async Task TestGetList()
        {
            await Resource.GetList();
            AssertRequest("GET", $"https://api.omise.co/customers/{CustomerId}/schedules");
        }

        protected override CustomerSpecificScheduleResource BuildResource(IRequester requester)
        {
            return new CustomerSpecificScheduleResource(requester, CustomerId);
        }
    }
}
