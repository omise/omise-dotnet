using System;
using Omise.Models;

namespace Omise.Resources {
    public class TokenResource : BaseResource<Token>,
    ICreatable<Token, CreateTokenRequest>,
    IListable<Token> {
        // TODO: We're not listable.
        public TokenResource(IRequester requester)
            : base(requester, Endpoint.Vault, "/tokens") {
        }
    }
}

