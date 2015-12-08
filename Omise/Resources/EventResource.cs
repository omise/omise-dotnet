using System;
using Omise.Resources;
using Omise.Models;

namespace Omise.Resources {
    public class EventResource : BaseResource<Event>,
    IListable<Event>,
    IListRetrivable<Event> {
        public EventResource(IRequester requester)
            : base(requester, Endpoint.Api, "/events") {
        }
    }
}

