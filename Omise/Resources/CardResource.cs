using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class CardResource : BaseResource<Card>,
        IDestroyable<Card>,
        IListable<Card>,
        IListRetrievable<Card>,
        IUpdatable<Card, UpdateCardParams>
    {
        public CardResource(IRequester requester)
        : base(requester, Endpoint.Api, "/customers")
        {
        }
    }
}