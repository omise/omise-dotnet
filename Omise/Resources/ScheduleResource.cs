using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class ScheduleResource : BaseResource<Schedule>,
        ICreatable<Schedule, CreateScheduleParams>,
        IDestroyable<Schedule>,
        IListable<Schedule>,
        IRetrievable<Schedule>
    {
        public ScheduleOccurrenceResource Occurrences { get; private set; }

        public ScheduleResource(IRequester requester)
        : base(requester, Endpoint.Api, "/schedules")
        {
        }

        public ScheduleResource Schedule(string scheduleId)
        {
            Occurrences = new ScheduleOccurrenceResource(Requester, scheduleId);

            return this;
        }
    }

    public class ScheduleOccurrenceResource : BaseResource<Occurrence>,
        IListable<Occurrence>
    {
        public ScheduleOccurrenceResource(IRequester requester, string scheduleId)
        : base(requester, Endpoint.Api, $"/schedules/{scheduleId}/occurrences")
        {
        }
    }
}