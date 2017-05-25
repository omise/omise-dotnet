using Omise.Models;

namespace Omise.Resources
{
    public class CustomerSpecificScheduleResource : BaseResource<Schedule>,
    IListable<Schedule>
    {
        public CustomerSpecificScheduleResource(IRequester requester, string customerId)
            : base(requester, Endpoint.Api, $"/customers/{customerId}/schedules")
        {
        }
    }
}
