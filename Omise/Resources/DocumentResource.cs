using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class DocumentResource : BaseResource<Document>,
        IDestroyable<Document>,
        IRetrievable<Document>,
        IListable<Document>,
        ICreatable<Document, CreateDocumentParams>
    {
        public DocumentResource(IRequester requester)
        : base(requester, Endpoint.Api, "/disputes")
        {
        }
    }
}