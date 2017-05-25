using Omise.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Omise.Resources
{
    public class TokenRequestWrapper : Request
    {
        [JsonProperty("card")]
        public CreateTokenRequest Card { get; set; }
    }

    public class TokenResource : BaseResource<Token>,
    IListRetrievable<Token>
    {
        public TokenResource(IRequester requester)
            : base(requester, Endpoint.Vault, "/tokens")
        {
        }

        public async Task<Token> Create(CreateTokenRequest request)
        {
            var wrapped = new TokenRequestWrapper { Card = request };
            return await Requester.Request<TokenRequestWrapper, Token>(
                Endpoint, "POST", BasePath, wrapped
            );
        }
    }
}