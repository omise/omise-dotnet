using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class ChargeResource : BaseResource<Charge>,
        IListable<Charge>,
        ICreatable<Charge, CreateChargeParams>,
        IRetrievable<Charge>,
        IUpdatable<Charge, UpdateChargeParams>,
        ISearchable<Charge>
    {
        public ChargeEventResource Events { get; private set; }
        public ChargeScheduleResource Schedules { get; private set; }
        public ChargeRefundResource Refunds { get; private set; }
        public SearchScope Scope => SearchScope.Charge;

        public ChargeResource(IRequester requester)
        : base(requester, Endpoint.Api, "/charges")
        {
            Schedules = new ChargeScheduleResource(Requester);
        }

        public ChargeResource Charge(string chargeId)
        {
            Events = new ChargeEventResource(Requester, chargeId);
            Refunds = new ChargeRefundResource(Requester, chargeId);

            return this;
        }

        public async Task<Charge> Capture(string chargeId)
        {
            return await Requester.Request<Charge>(
                Endpoint,
                "POST",
                $"{BasePath}/{chargeId}/capture"
            );
        }

        public async Task<Charge> Expire(string chargeId)
        {
            return await Requester.Request<Charge>(
                Endpoint,
                "POST",
                $"{BasePath}/{chargeId}/expire"
            );
        }

        public async Task<Charge> MarkAsFailed(string chargeId)
        {
            return await Requester.Request<Charge>(
                Endpoint,
                "POST",
                $"{BasePath}/{chargeId}/mark_as_failed"
            );
        }

        public async Task<Charge> MarkAsPaid(string chargeId)
        {
            return await Requester.Request<Charge>(
                Endpoint,
                "POST",
                $"{BasePath}/{chargeId}/mark_as_paid"
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

    public class ChargeRefundResource : BaseResource<Refund>,
        ICreatable<Refund, CreateChargeRefundParams>,
        IListable<Refund>,
        IRetrievable<Refund>
    {
        public ChargeRefundResource(IRequester requester, string chargeId)
        : base(requester, Endpoint.Api, $"/charges/{chargeId}/refunds")
        {
        }
    }
}