using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class TransactionResource : BaseResource<Transaction>,
        IListable<Transaction>
        IRetrievable<Transaction>,
    {
        public TransactionResource(IRequester requester)
        : base(requester, Endpoint.Api, "/transactions")
        {
        }
    }
}