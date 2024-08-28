using System;
using Omise.Models;

namespace Omise.Resources
{
    public class StatusSpecificDispute : BaseResource<Dispute>,
    IListable<Dispute>
    {
        public StatusSpecificDispute(DisputeStatus status, IRequester requester)
            : base(requester, Endpoint.Api, pathForStatus(status))
        {
        }

        static string pathForStatus(DisputeStatus status)
        {
            switch (status)
            {
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
