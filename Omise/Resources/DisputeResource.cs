using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class DisputeResource : BaseResource<Dispute>,
        IListable<Dispute>,
        IListRetrievable<Dispute>,
        IUpdatable<Dispute, UpdateDisputeParams>,
        ISearchable<Dispute>
    {
        public SearchScope Scope => SearchScope.Dispute;

        public DisputeResource(IRequester requester)
        : base(requester, Endpoint.Api, "/disputes")
        {
        }

        public async Task<Dispute> Closed() {
            return await Requester.Request<Dispute>(
                Endpoint,
                "GET",
                $"{BasePath}/closed"
            );
        }

        public async Task<Dispute> Open() {
            return await Requester.Request<Dispute>(
                Endpoint,
                "GET",
                $"{BasePath}/open"
            );
        }

        public async Task<Dispute> Pending() {
            return await Requester.Request<Dispute>(
                Endpoint,
                "GET",
                $"{BasePath}/pending"
            );
        }
    }
}