using Omise.Models;

namespace Omise
{
    public interface IResource<TModel> where TModel : ModelBase
    {
        IRequester Requester { get; }

        Endpoint Endpoint { get; }
        string BasePath { get; }
    }
}