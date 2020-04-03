using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class EventResource : BaseResource<Event>,
        IListable<Event>,
        IRetrievable<Event>
    {
        public EventResource(IRequester requester)
        : base(requester, Endpoint.Api, "/events")
        {
        }
    }
}