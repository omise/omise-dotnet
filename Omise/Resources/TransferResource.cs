using Omise.Models;

namespace Omise.Resources {
    public class TransferResource : BaseResource<Transfer>,
    IListable<Transfer>,
    IListRetrievable<Transfer>,
    ICreatable<Transfer, CreateTransferRequest>,
    IUpdatable<Transfer, UpdateTransferRequest>,
    IDestroyable<Transfer> {
        public TransferResource(IRequester requester)
            : base(requester, Endpoint.Api, "/transfers") {
        }
    }
}