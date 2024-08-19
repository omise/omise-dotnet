using System;
using Omise.Models;

namespace Omise.Resources
{
    public class DisputeResource : BaseResource<Dispute>,
    IListable<Dispute>,
    IListRetrievable<Dispute>,
    IUpdatable<Dispute, UpdateDisputeRequest>,
    ISearchable<Dispute>
    {
        public readonly StatusSpecificDispute OpenDisputes;
        public readonly StatusSpecificDispute PendingDisputes;
        public readonly StatusSpecificDispute WonDisputes;
        public readonly StatusSpecificDispute LostDisputes;

        public SearchScope Scope => SearchScope.Dispute;

        public DisputeResource(IRequester requester)
            : base(requester, Endpoint.Api, "/disputes")
        {
            OpenDisputes = new StatusSpecificDispute(DisputeStatus.Open, requester);
            PendingDisputes = new StatusSpecificDispute(DisputeStatus.Pending, requester);
            WonDisputes = new StatusSpecificDispute(DisputeStatus.Won, requester);
            LostDisputes = new StatusSpecificDispute(DisputeStatus.Lost, requester);
        }
    }

}