using Omise.Models;

namespace Omise.Resources
{
    public class RecipientSpecificResource : BaseResource<Recipient>,
    IRetrievable<Recipient>
    {
        public readonly RecipientSpecificScheduleResource Schedules;

        public RecipientSpecificResource(IRequester requester, string recipientId)
            : base(requester, Endpoint.Api, $"/recipients/{recipientId}/schedules")
        {
            Schedules = new RecipientSpecificScheduleResource(requester, recipientId);
        }
    }
}
