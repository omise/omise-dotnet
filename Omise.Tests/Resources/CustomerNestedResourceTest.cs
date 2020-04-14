using NUnit.Framework;
using Omise.Resources;

namespace Omise.Tests.Resources
{
    public class CustomerNestedResourceTest : ResourceTest<CustomerResource>
    {
        const string CustomerId = "cust_test_4yq6txdpfadhbaqnwp3";

        [Test]
        public void TestCards()
        {
            Assert.AreEqual($"/customers/{CustomerId}/cards", Resource.Cards.BasePath);
            Assert.IsInstanceOf(typeof(CustomerCardResource), Resource.Cards);
        }

        [Test]
        public void TestSchedules()
        {
            Assert.AreEqual($"/customers/{CustomerId}/schedules", Resource.Schedules.BasePath);
            Assert.IsInstanceOf(typeof(CustomerScheduleResource), Resource.Schedules);
        }

        protected override CustomerResource BuildResource(IRequester requester)
        {
            return new CustomerResource(requester).Customer(CustomerId);
        }
    }
}
