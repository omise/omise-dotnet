using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class TransferResource : BaseResource<Transfer>,
        IDestroyable<Transfer>,
        IListable<Transfer>,
        IListRetrievable<Transfer>,
        ICreatable<Transfer, CreateTransferParams>,
        IUpdatable<Transfer, UpdateTransferParams>,
        ISearchable<Transfer>
    {
        public TransferScheduleResource Schedules { get; private set; }
        public SearchScope Scope => SearchScope.Transfer;

        public TransferResource(IRequester requester)
        : base(requester, Endpoint.Api, "/transfers")
        {
            Schedules = new TransferScheduleResource(Requester);
        }

        public async Task<Transfer> MarkAsPaid(string transferId) {
            return await Requester.Request<Transfer>(
                Endpoint,
                "POST",
                $"{BasePath}/{transferId}/mark_as_paid"
            );
        }

        public async Task<Transfer> MarkAsSent(string transferId) {
            return await Requester.Request<Transfer>(
                Endpoint,
                "POST",
                $"{BasePath}/{transferId}/mark_as_sent"
            );
        }
    }

    public class TransferScheduleResource : BaseResource<Schedule>,
        IListable<Schedule>
    {
        public TransferScheduleResource(IRequester requester)
        : base(requester, Endpoint.Api, "/transfers/schedules")
        {
        }
    }
}