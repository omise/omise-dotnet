using Omise.Models;
using System.Threading.Tasks;

namespace Omise
{
    public interface ICreatable<TModel, TRequest> : IResource<TModel>
        where TModel : ModelBase
        where TRequest : Request
    {
    }

    public static class Creatables
    {
        public static async Task<TModel> Create<TModel, TRequest>(
            this ICreatable<TModel, TRequest> resource,
            TRequest request
        ) where TModel : ModelBase
            where TRequest : Request
        {
            return await resource.Requester.Request<TRequest, TModel>(
                resource.Endpoint,
                "POST",
                resource.BasePath,
                request
            );
        }
    }
}

