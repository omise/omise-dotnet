using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class ChargeResource : BaseResource<Charge>,
        IListable<Charge>,
        IListRetrievable<Charge>,
        IUpdatable<Charge, UpdateChargeParams>,
        ICreatable<Charge, CreateChargeParams>,
        ISearchable<Charge>
    {
        public ChargeRefundResource Refunds { get; private set; }
        public ChargeEventResource Events { get; private set; }
        public ChargeScheduleResource Schedules { get; private set; }
        public SearchScope Scope => SearchScope.Charge;

        public ChargeResource(IRequester requester)
        : base(requester, Endpoint.Api, "/charges")
        {
            Schedules = new ChargeScheduleResource(Requester);
        }

        public ChargeResource Charge(string chargeId) {
            Refunds = new ChargeRefundResource(Requester, chargeId);
            Events = new ChargeEventResource(Requester, chargeId);

            return this;
        }

        public async Task<Charge> Capture(string chargeId) {
            return await Requester.Request<Charge>(
                Endpoint,
                "POST",
                $"{BasePath}/{chargeId}/capture"
            );
        }

        public async Task<Charge> Expire(string chargeId) {
            return await Requester.Request<Charge>(
                Endpoint,
                "POST",
                $"{BasePath}/{chargeId}/expire"
            );
        }

        public async Task<Charge> MarkAsFailed(string chargeId) {
            return await Requester.Request<Charge>(
                Endpoint,
                "POST",
                $"{BasePath}/{chargeId}/mark_as_failed"
            );
        }

        public async Task<Charge> MarkAsPaid(string chargeId) {
            return await Requester.Request<Charge>(
                Endpoint,
                "POST",
                $"{BasePath}/{chargeId}/mark_as_paid"
            );
        }

        public async Task<Charge> Reverse(string chargeId) {
            return await Requester.Request<Charge>(
                Endpoint,
                "POST",
                $"{BasePath}/{chargeId}/reverse"
            );
        }
    }

    public class ChargeRefundResource : BaseResource<Refund>,
        IListable<Refund>,
        IListRetrievable<Refund>,
        ICreatable<Refund, CreateChargeRefundParams>
    {
        public ChargeRefundResource(IRequester requester, string chargeId)
        : base(requester, Endpoint.Api, $"/charges/{chargeId}/refunds")
        {
        }
    }

    public class ChargeEventResource : BaseResource<Event>,
        IListable<Event>
    {
        public ChargeEventResource(IRequester requester, string chargeId)
        : base(requester, Endpoint.Api, $"/charges/{chargeId}/events")
        {
        }
    }

    public class ChargeScheduleResource : BaseResource<Schedule>,
        IListable<Schedule>
    {
        public ChargeScheduleResource(IRequester requester)
        : base(requester, Endpoint.Api, "/charges/schedules")
        {
        }
    }
}