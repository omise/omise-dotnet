using Omise.Models;

namespace Omise.Resources
{
    public class ForexResource : BaseResource<Forex>,
    IListRetrievable<Forex>
    {
        public ForexResource(IRequester requester)
            : base(requester, Endpoint.Api, "/forex")
        {
        }
    }
}
