using Omise.Models;

namespace Omise.Resources {
    public class TokenResource : BaseResource<Token>,
    IListRetrievable<Token>,
    ICreatable<Token, CreateTokenRequest> {
        // TODO: We're not listable.
        public TokenResource(IRequester requester)
            : base(requester, Endpoint.Vault, "/tokens") {
        }
    }
}