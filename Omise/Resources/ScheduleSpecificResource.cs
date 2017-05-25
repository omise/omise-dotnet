using Omise.Models;

namespace Omise.Resources
{
    public class ScheduleSpecificResource : BaseResource<Schedule>
    {
        public readonly ScheduleSpecificOccurrenceResource Occurrences;

        public ScheduleSpecificResource(IRequester requester, string scheduleId)
            : base(requester, Endpoint.Api, $"/schedules/{scheduleId}")
        {
            Occurrences = new ScheduleSpecificOccurrenceResource(requester, scheduleId);
        }
    }
}
