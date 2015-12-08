using System;
using Omise.Models;

namespace Omise.Resources {
    public class RefundResource : BaseResource<Refund>,
    IListable<Refund>,
    IListRetrievable<Refund>,
    ICreatable<Refund, CreateRefundRequest> {
        public RefundResource(IRequester requester, string chargeId)
            : base(requester, Endpoint.Api, basePathFor(chargeId)) {
        }

        static string basePathFor(string chargeId) {
            return "/charges/" + chargeId + "/refunds";
        }
    }
}

