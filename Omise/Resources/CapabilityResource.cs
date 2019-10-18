using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class CapabilityResource : BaseResource<Capability>,
        IListRetrievable<Capability>
    {
        public CapabilityResource(IRequester requester)
        : base(requester, Endpoint.Api, "/capability")
        {
        }
    }
}