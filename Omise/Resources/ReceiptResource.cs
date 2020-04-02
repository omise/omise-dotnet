using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class ReceiptResource : BaseResource<Receipt>,
        IListable<Receipt>,
        IRetrievable<Receipt>
    {
        public ReceiptResource(IRequester requester)
        : base(requester, Endpoint.Api, "/receipts")
        {
        }
    }
}