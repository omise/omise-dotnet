using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class LinkResource : BaseResource<Link>,
        ICreatable<Link, CreateLinkParams>,
        IDestroyable<Link>,
        IListable<Link>,
        IRetrievable<Link>,
        ISearchable<Link>
    {
        public LinkChargeResource Charges { get; private set; }
        public SearchScope Scope => SearchScope.Link;

        public LinkResource(IRequester requester)
        : base(requester, Endpoint.Api, "/links")
        {
        }

        public LinkResource Link(string linkId)
        {
            Charges = new LinkChargeResource(Requester, linkId);

            return this;
        }
    }

    public class LinkChargeResource : BaseResource<Charge>,
        IListable<Charge>
    {
        public LinkChargeResource(IRequester requester, string linkId)
        : base(requester, Endpoint.Api, $"/links/{linkId}/charges")
        {
        }
    }
}