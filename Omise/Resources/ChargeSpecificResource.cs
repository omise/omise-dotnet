using System;
using Omise.Models;

namespace Omise.Resources
{
    public class ChargeSpecificResource : BaseResource<Charge>
    {
        public readonly ChargeSpecificRefundResource Refunds;

        public ChargeSpecificResource(IRequester requester, string chargeId)
            : base(requester, Endpoint.Api, $"/charges/{chargeId}")
        {
            Refunds = new ChargeSpecificRefundResource(requester, chargeId);
        }
    }
}
