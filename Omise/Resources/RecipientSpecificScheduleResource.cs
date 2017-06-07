using Omise.Models;

namespace Omise.Resources
{
    public class RecipientSpecificScheduleResource : BaseResource<Schedule>,
    IListable<Schedule>
    {
        public RecipientSpecificScheduleResource(IRequester requester, string recipientId)
            : base(requester, Endpoint.Api, $"/recipients/{recipientId}/schedules")
        {
        }
    }
}
