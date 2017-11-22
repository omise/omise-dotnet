using System;
using Omise.Models;

namespace Omise.Resources
{
    public class PaymentSourceResource : BaseResource<PaymentSource>,
    IListable<PaymentSource>,
    IListRetrievable<PaymentSource>,
    ICreatable<PaymentSource, CreatePaymentSourceRequest>
    {
        public PaymentSourceResource(IRequester requester)
            : base(requester, Endpoint.Api, "/sources")
        {
        }
    }
}
