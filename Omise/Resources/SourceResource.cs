using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class SourceResource : BaseResource<Source>,
        ICreatable<Source, CreateSourceParams>,
        IListRetrievable<Source>
    {
        public SourceResource(IRequester requester)
        : base(requester, Endpoint.Api, "/sources")
        {
        }
    }
}