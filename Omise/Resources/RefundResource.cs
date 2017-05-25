using System;
using Omise.Models;

namespace Omise.Resources
{
    public class RefundResource : BaseResource<Refund>,
    IListable<Refund>,
    ISearchable<Refund>
    {
        public SearchScope Scope => SearchScope.Refund;

        public RefundResource(IRequester requester)
            : base(requester, Endpoint.Api, "/refunds")
        {
        }
    }
}
