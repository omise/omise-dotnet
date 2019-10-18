using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class TransactionResource : BaseResource<Transaction>,
        IListRetrievable<Transaction>,
        IListable<Transaction>
    {
        public TransactionResource(IRequester requester)
        : base(requester, Endpoint.Api, "/transactions")
        {
        }
    }
}