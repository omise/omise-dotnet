using Omise.Models;

namespace Omise.Resources
{
    public class OccurrenceResource : BaseResource<Occurrence>,
    IListRetrievable<Occurrence>
    {
        public OccurrenceResource(IRequester requester)
            : base(requester, Endpoint.Api, "/occurrences")
        {
        }
    }
}
