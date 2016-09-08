using System;
using Omise.Models;

namespace Omise.Resources {
    public class DisputeResource : BaseResource<Dispute>,
    IListable<Dispute>,
    IListRetrievable<Dispute>,
    IUpdatable<Dispute, UpdateDisputeRequest>,
    ISearchable<Dispute> {
        public StatusSpecificDispute OpenDisputes { get; private set; }
        public StatusSpecificDispute PendingDisputes { get; private set; }
        public StatusSpecificDispute ClosedDisputes { get; private set; }

        public SearchScope Scope => SearchScope.Dispute;

        public DisputeResource(IRequester requester)
            : base(requester, Endpoint.Api, "/disputes") {
            OpenDisputes = new StatusSpecificDispute(DisputeStatus.Open, requester);
            PendingDisputes = new StatusSpecificDispute(DisputeStatus.Pending, requester);
            ClosedDisputes = new StatusSpecificDispute(DisputeStatus.Closed, requester);
        }
    }

    // TODO: Convert to nested resource?
    public class StatusSpecificDispute : BaseResource<Dispute>,
    IListable<Dispute> {
        public StatusSpecificDispute(DisputeStatus status, IRequester requester)
            : base(requester, Endpoint.Api, pathForStatus(status)) {
        }

        static string pathForStatus(DisputeStatus status) {
            switch (status) {
                case DisputeStatus.Open:
                    return "/disputes/open";
                case DisputeStatus.Pending:
                    return "/disputes/pending";
                case DisputeStatus.Closed:
                case DisputeStatus.Won:
                case DisputeStatus.Lost:
                    return "/disputes/closed";

                default:
                    throw new ArgumentException("status");
            }
        }
    }
}