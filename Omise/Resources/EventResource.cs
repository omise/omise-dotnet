using Omise.Models;

namespace Omise.Resources {
    public class EventResource : BaseResource<Event>,
    IListable<Event>,
    IListRetrievable<Event> {
        public EventResource(IRequester requester)
            : base(requester, Endpoint.Api, "/events") {
        }
    }
}

