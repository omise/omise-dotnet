using Omise.Models;

namespace Omise.Resources {
    public class LinkResource : BaseResource<Link>,
    IListable<Link>,
    IListRetrievable<Link>,
    ICreatable<Link, CreateLinkRequest> {
        public LinkResource(IRequester requester)
            : base(requester, Endpoint.Api, "/links") {
        }
    }
}
