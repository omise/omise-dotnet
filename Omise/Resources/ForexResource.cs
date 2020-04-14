using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class ForexResource : BaseResource<Forex>,
        IRetrievable<Forex>
    {
        public ForexResource(IRequester requester)
        : base(requester, Endpoint.Api, "/forex")
        {
        }
    }
}