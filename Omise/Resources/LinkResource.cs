using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class LinkResource : BaseResource<Link>,
        IDestroyable<Link>,
        IRetrievable<Link>,
        IListable<Link>,
        ICreatable<Link, CreateLinkParams>,
        ISearchable<Link>
    {
        public SearchScope Scope => SearchScope.Link;

        public LinkResource(IRequester requester)
        : base(requester, Endpoint.Api, "/links")
        {
        }

        public async Task<Link> ListCharges(string linkId) {
            return await Requester.Request<Link>(
                Endpoint,
                "GET",
                $"{BasePath}/{linkId}/charges"
            );
        }
    }
}