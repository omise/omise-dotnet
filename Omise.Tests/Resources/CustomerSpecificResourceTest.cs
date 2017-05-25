using NUnit.Framework;
using Omise.Resources;

namespace Omise.Tests.Resources
{
    public class CustomerSpecificResourceTest : ResourceTest<CustomerSpecificResource>
    {
        const string CustomerId = "cust_test_4yq6txdpfadhbaqnwp3";

        [Test]
        public void TestBasePath()
        {
            Assert.IsTrue(Resource.BasePath.Contains(CustomerId));
        }

        [Test]
        public void TestCards()
        {
            Assert.IsTrue(Resource.Cards.BasePath.Contains(CustomerId));
            Assert.IsNotNull(Resource.Cards);
        }

        [Test]
        public void TestSchedules()
        {
            Assert.IsTrue(Resource.BasePath.Contains(CustomerId));
            Assert.IsNotNull(Resource.Schedules);
        }

        protected override CustomerSpecificResource BuildResource(IRequester requester)
        {
            return new CustomerSpecificResource(requester, CustomerId);
        }
    }
}
