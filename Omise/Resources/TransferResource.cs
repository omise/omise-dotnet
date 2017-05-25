using System;
using Omise.Models;

namespace Omise.Resources
{
    public class TransferResource : BaseResource<Transfer>,
    IListable<Transfer>,
    IListRetrievable<Transfer>,
    ICreatable<Transfer, CreateTransferRequest>,
    IUpdatable<Transfer, UpdateTransferRequest>,
    IDestroyable<Transfer>,
    ISearchable<Transfer>
    {
        public SearchScope Scope => SearchScope.Transfer;

        public TransferResource(IRequester requester)
            : base(requester, Endpoint.Api, "/transfers")
        {
        }
    }
}