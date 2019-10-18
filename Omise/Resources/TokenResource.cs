using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class TokenResource : BaseResource<Token>,
        ICreatable<Token, CreateTokenParams>,
        IListRetrievable<Token>
    {
        public TokenResource(IRequester requester)
        : base(requester, Endpoint.Vault, "/tokens")
        {
        }
    }
}