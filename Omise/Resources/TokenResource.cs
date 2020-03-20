using System.Threading.Tasks;
using Omise.Models;
using Newtonsoft.Json;

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

        public async Task<Token> Create(CreateCardParams request)
        {
            var wrapped = new CreateTokenParams { Card = request };
            return await Requester.Request<CreateTokenParams, Token>(
                Endpoint, "POST", BasePath, wrapped
            );
        }
    }
}