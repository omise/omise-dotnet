using Omise.Models;

namespace Omise.Resources
{
    public class CustomerSpecificCardResource : BaseResource<Card>,
    IListable<Card>,
    IListRetrievable<Card>,
    IUpdatable<Card, UpdateCardRequest>,
    IDestroyable<Card>
    {
        public CustomerSpecificCardResource(IRequester requester, string customerId)
            : base(requester, Endpoint.Api, $"/customers/{customerId}/cards")
        {
        }
    }
}