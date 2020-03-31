using System;
using Omise.Resources;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace Omise.Tests.Resources
{
    public class ScheduleNestedResourceTest : ResourceTest<ScheduleResource>
    {
        const string ScheduleId = "schd_test_57weuktrvln3bhtfolm";

        [Test]
        public void TestOccurrences()
        {
            Assert.AreEqual($"/schedules/{ScheduleId}/occurrences", Resource.Occurrences.BasePath);
            Assert.IsInstanceOf(typeof(ScheduleOccurrenceResource), Resource.Occurrences);
        }

        protected override ScheduleResource BuildResource(IRequester requester)
        {
            return new ScheduleResource(requester).Schedule(ScheduleId);
        }
    }
}
