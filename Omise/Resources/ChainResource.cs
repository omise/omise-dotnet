using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class ChainResource : BaseResource<Chain>,
        IListable<Chain>,
        IRetrievable<Chain>
    {
        public ChainResource(IRequester requester)
        : base(requester, Endpoint.Api, "/chains")
        {
        }

        public async Task<Chain> Revoke(string chainId) {
            return await Requester.Request<Chain>(
                Endpoint,
                "POST",
                $"{BasePath}/{chainId}/revoke"
            );
        }
    }
}