using Omise.Models;

namespace Omise.Resources {
    public class RecipientResource : BaseResource<Recipient>,
    IListable<Recipient>,
    IListRetrievable<Recipient>,
    ICreatable<Recipient, CreateRecipientRequest>,
    IUpdatable<Recipient, UpdateRecipientRequest>,
    IDestroyable<Recipient>,
    ISearchable<Recipient> {
        public SearchScope Scope => SearchScope.Recipient;

        public RecipientResource(IRequester requester)
            : base(requester, Endpoint.Api, "/recipients") {
        }
    }
}

