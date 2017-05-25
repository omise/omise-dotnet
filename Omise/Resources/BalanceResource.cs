using Omise.Models;

namespace Omise.Resources
{
    public class BalanceResource : BaseResource<Balance>, IRetrievable<Balance>
    {
        public BalanceResource(IRequester requester)
            : base(requester, Endpoint.Api, "/balance")
        {
        }
    }
}