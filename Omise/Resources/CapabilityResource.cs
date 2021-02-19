using Omise.Models;

namespace Omise.Resources
{
    public class CapabilityResource : BaseResource<Capability>,
        IRetrievable<Capability>
    {
        public CapabilityResource(IRequester requester)
            : base(requester, Endpoint.Api, "/capability")
        {
        }
    }
}
