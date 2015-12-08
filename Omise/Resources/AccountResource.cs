using System;
using Omise.Models;
using System.Threading.Tasks;

namespace Omise.Resources {
    public class AccountResource : BaseResource<Account>, IRetrievable<Account> {
        public AccountResource(IRequester requester)
            : base(requester, Endpoint.Api, "/account") {
        }
    }
}

