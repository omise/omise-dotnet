using Omise.Models;

namespace Omise.Resources {
    public class BaseResource<TModel> : IResource<TModel> where TModel : ModelBase {
        public IRequester Requester { get; private set; }
        public Endpoint Endpoint { get; private set; }
        public string BasePath { get; private set; }

        public BaseResource(IRequester requester, Endpoint endpoint, string basePath) {
            Requester = requester;
            Endpoint = endpoint;
            BasePath = basePath;
        }
    }
}