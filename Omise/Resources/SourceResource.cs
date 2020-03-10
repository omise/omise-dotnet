using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class SourceResource : BaseResource<PaymentSource>,
        ICreatable<PaymentSource, CreateSourceParams>,
        IListRetrievable<PaymentSource>
    {
        public SourceResource(IRequester requester)
        : base(requester, Endpoint.Api, "/sources")
        {
        }
    }
}