using Omise.Models;

namespace Omise.Resources
{
    public class ScheduleResource : BaseResource<Schedule>,
    IListable<Schedule>,
    IListRetrievable<Schedule>,
    ICreatable<Schedule, CreateScheduleRequest>,
    IDestroyable<Schedule>
    {
        public ScheduleResource(IRequester requester)
            : base(requester, Endpoint.Api, "/schedules")
        {
        }
    }
}
