using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class CardResource : BaseResource<Card>,
        IDestroyable<Card>,
        IListRetrievable<Card>,
        IUpdatable<Card, UpdateCardParams>,
        IListable<Card>
    {
        public CardResource(IRequester requester)
        : base(requester, Endpoint.Api, "/customers")
        {
        }
    }
}