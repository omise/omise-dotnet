using System.Threading.Tasks;
using Omise.Models;
using System;

namespace Omise.Resources
{
    public class DisputeResource : BaseResource<Dispute>,
        IListable<Dispute>,
        IRetrievable<Dispute>,
        ISearchable<Dispute>,
        IUpdatable<Dispute, UpdateDisputeParams>
    {
        public DisputeDocumentResource Documents { get; private set; }
        public SearchScope Scope => SearchScope.Dispute;

        public DisputeResource(IRequester requester)
        : base(requester, Endpoint.Api, "/disputes")
        {
        }

        public DisputeResource Dispute(string disputeId)
        {
            Documents = new DisputeDocumentResource(Requester, disputeId);

            return this;
        }

        public async Task<ScopedList<Dispute>> ListClosed(int? offset = null, int? limit = null, DateTime? from = null, DateTime? to = null, Ordering? order = null)
        {
            return await this.GetList($"{BasePath}/closed", offset, limit, from, to, order);
        }

        public async Task<ScopedList<Dispute>> ListOpen(int? offset = null, int? limit = null, DateTime? from = null, DateTime? to = null, Ordering? order = null)
        {
            return await this.GetList($"{BasePath}/open", offset, limit, from, to, order);
        }

        public async Task<ScopedList<Dispute>> ListPending(int? offset = null, int? limit = null, DateTime? from = null, DateTime? to = null, Ordering? order = null)
        {
            return await this.GetList($"{BasePath}/pending", offset, limit, from, to, order);
        }
    }

    public class DisputeDocumentResource : BaseResource<Document>,
        ICreatable<Document, CreateDisputeDocumentParams>,
        IDestroyable<Document>,
        IListable<Document>,
        IRetrievable<Document>
    {
        public DisputeDocumentResource(IRequester requester, string disputeId)
        : base(requester, Endpoint.Api, $"/disputes/{disputeId}/documents")
        {
        }
    }
}