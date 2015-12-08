using System;
using Omise.Models;

namespace Omise.Resources {
    public class CardResource : BaseResource<Card>,
    IListable<Card>,
    IListRetrievable<Card>,
    IUpdatable<Card, UpdateCardRequest>,
    IDestroyable<Card> {
        public CardResource(IRequester requester, string customerId)
            : base(requester, Endpoint.Api, basePathFor(customerId)) {
        }

        static string basePathFor(string customerId) {
            return "/customers/" + customerId + "/cards";
        }
    }
}

