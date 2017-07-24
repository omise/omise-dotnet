using Omise.Models;

namespace Omise.Resources
{
    public class ReceiptResource : BaseResource<Receipt>,
    IListRetrievable<Receipt>,
    IListable<Receipt>
    {
        public ReceiptResource(IRequester requester)
            : base(requester, Endpoint.Api, "/receipts")
        {
        }
    }
}
