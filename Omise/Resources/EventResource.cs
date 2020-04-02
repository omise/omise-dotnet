using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class EventResource : BaseResource<Event>,
        IRetrievable<Event>,
        IListable<Event>
    {
        public EventResource(IRequester requester)
        : base(requester, Endpoint.Api, "/events")
        {
        }
    }
}