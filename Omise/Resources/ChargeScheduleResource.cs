using Omise.Models;

namespace Omise.Resources
{
    public class ChargeScheduleResource : BaseResource<Schedule>,
    IListable<Charge>
    {
        public ChargeScheduleResource(IRequester requester)
            : base(requester, Endpoint.Api, "/charges/schedules")
        {
        }
    }
}
