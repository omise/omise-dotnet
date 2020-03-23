using Omise.Models;

namespace Omise.Resources
{
    public class ChargeSpecificRefundResource : BaseResource<Refund>,
    IListable<Refund>,
    IListRetrievable<Refund>,
    ICreatable<Refund, CreateRefundParams>
    {
        public ChargeSpecificRefundResource(IRequester requester, string chargeId)
            : base(requester, Endpoint.Api, $"/charges/{chargeId}/refunds")
        {
        }
    }
}