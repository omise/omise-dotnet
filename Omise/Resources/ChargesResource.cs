using Omise.Models;
using System.Threading.Tasks;

namespace Omise.Resources {
    public class ChargesResource : BaseResource<Charge>,
    IListable<Charge>,
    IListRetrievable<Charge>,
    ICreatable<Charge, CreateChargeRequest>,
    IUpdatable<Charge, UpdateChargeRequest> {
        public ChargesResource(IRequester requester)
            : base(requester, Endpoint.Api, "/charges") {
        }

        public async Task<Charge> Capture(string chargeId) {
            return await Requester.Request<Charge>(
                Endpoint,
                "POST",
                BasePath + "/" + chargeId + "/capture"
            );
        }
    }
}

