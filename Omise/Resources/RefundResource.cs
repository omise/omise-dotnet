using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class RefundResource : BaseResource<Refund>,
        ICreatable<Refund, CreateRefundParams>,
        IListable<Refund>,
        IRetrievable<Refund>,
        ISearchable<Refund>
    {
        public SearchScope Scope => SearchScope.Refund;

        public RefundResource(IRequester requester)
        : base(requester, Endpoint.Api, "/refunds")
        {
        }
    }
}