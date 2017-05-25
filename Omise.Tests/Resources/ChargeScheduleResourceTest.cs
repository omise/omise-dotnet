using System;
using NUnit.Framework;
using Omise.Resources;
using System.Threading.Tasks;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class ChargeScheduleResourceTest : ResourceTest<ChargeScheduleResource>
    {
        [Test]
        public async Task TestGetList()
        {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/charges/schedules");
        }

        protected override ChargeScheduleResource BuildResource(IRequester requester)
        {
            return new ChargeScheduleResource(requester);
        }
    }
}
