using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class RecipientResource : BaseResource<Recipient>,
        IDestroyable<Recipient>,
        IListable<Recipient>,
        IListRetrievable<Recipient>,
        IUpdatable<Recipient, UpdateRecipientParams>,
        ICreatable<Recipient, CreateRecipientParams>,
        ISearchable<Recipient>
    {
        public RecipientScheduleResource Schedules { get; private set; }
        public SearchScope Scope => SearchScope.Recipient;

        public RecipientResource(IRequester requester)
        : base(requester, Endpoint.Api, "/recipients")
        {
        }

        public RecipientResource Recipient(string recipientId) {
            Schedules = new RecipientScheduleResource(Requester, recipientId);

            return this;
        }

        public async Task<Recipient> Verify(string recipientId) {
            return await Requester.Request<Recipient>(
                Endpoint,
                "PATCH",
                $"{BasePath}/{recipientId}/verify"
            );
        }
    }

    public class RecipientScheduleResource : BaseResource<Schedule>,
        IListable<Schedule>
    {
        public RecipientScheduleResource(IRequester requester, string recipientId)
        : base(requester, Endpoint.Api, $"/recipients/{recipientId}/schedules")
        {
        }
    }
}