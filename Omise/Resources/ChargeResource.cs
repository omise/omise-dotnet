using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class ChargeResource : BaseResource<Charge>,
    IListable<Charge>,
    IListRetrievable<Charge>,
    ICreatable<Charge, CreateChargeRequest>,
    IUpdatable<Charge, UpdateChargeRequest>,
    ISearchable<Charge>
    {
        public readonly ChargeScheduleResource Schedules;

        public SearchScope Scope => SearchScope.Charge;

        public ChargeResource(IRequester requester)
            : base(requester, Endpoint.Api, "/charges")
        {
            Schedules = new ChargeScheduleResource(requester);
        }

        public async Task<Charge> Capture(string chargeId)
        {
            return await Requester.Request<Charge>(
                Endpoint,
                "POST",
                $"{BasePath}/{chargeId}/capture"
            );
        }

        public async Task<Charge> Reverse(string chargeId)
        {
            return await Requester.Request<Charge>(
                Endpoint,
                "POST",
                $"{BasePath}/{chargeId}/reverse"
            );
        }
    }
}