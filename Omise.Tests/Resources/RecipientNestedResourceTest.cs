using System;
using Omise.Resources;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace Omise.Tests.Resources
{
    public class RecipientNestedResourceTest : ResourceTest<RecipientResource>
    {
        const string RecipientId = "recp_test_50894vc13y8z4v51iuc";

        [Test]
        public void TestSchedules()
        {
            Assert.AreEqual($"/recipients/{RecipientId}/schedules", Resource.Schedules.BasePath);
            Assert.IsInstanceOf(typeof(RecipientScheduleResource), Resource.Schedules);
        }

        protected override RecipientResource BuildResource(IRequester requester)
        {
            return new RecipientResource(requester).Recipient(RecipientId);
        }
    }
}
