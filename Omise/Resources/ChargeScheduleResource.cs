using Omise.Models;

namespace Omise.Resources
{
    public class ChargeScheduleResource : BaseResource<Schedule>,
    IListable<Schedule>
    {
        public ChargeScheduleResource(IRequester requester)
            : base(requester, Endpoint.Api, "/charges/schedules")
        {
        }
    }
}
