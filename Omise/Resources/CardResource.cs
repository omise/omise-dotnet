using Omise.Models;

namespace Omise.Resources {
    public class CardResourceShim {
        readonly IRequester requester;

        public CardResourceShim(IRequester requester) {
            this.requester = requester;
        }

        public CardResource ByCustomer(string customerId) {
            return new CardResource(requester, customerId);
        }
    }

    public class CardResource : BaseResource<Card>,
    IListable<Card>,
    IListRetrievable<Card>,
    IUpdatable<Card, UpdateCardRequest>,
    IDestroyable<Card> {
        public CardResource(IRequester requester, string customerId)
            : base(requester, Endpoint.Api, basePathFor(customerId)) {
        }

        static string basePathFor(string customerId) {
            return $"/customers/{customerId}/cards";
        }
    }
}