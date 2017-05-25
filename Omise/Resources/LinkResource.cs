using System;
using Omise.Models;

namespace Omise.Resources
{
    public class LinkResource : BaseResource<Link>,
    IListable<Link>,
    IListRetrievable<Link>,
    ICreatable<Link, CreateLinkRequest>,
    ISearchable<Link>
    {
        public SearchScope Scope => SearchScope.Link;

        public LinkResource(IRequester requester)
            : base(requester, Endpoint.Api, "/links")
        {
        }
    }
}
