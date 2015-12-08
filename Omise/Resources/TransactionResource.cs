using System;
using Omise.Models;

namespace Omise.Resources {
    public class TransactionResource : BaseResource<Transaction>,
    IListable<Transaction>,
    IListRetrivable<Transaction> {
        public TransactionResource(IRequester requester)
            : base(requester, Endpoint.Api, "/transactions") {
        }
    }
}

