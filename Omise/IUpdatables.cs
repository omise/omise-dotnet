using System.Threading.Tasks;
using Omise.Models;

namespace Omise
{
    public interface IUpdatable<TModel, TRequest> : IResource<TModel>
        where TModel : ModelBase
        where TRequest : Request
    {
    }

    public static class Updatables
    {
        public static async Task<TModel> Update<TModel, TRequest>(
            this IUpdatable<TModel, TRequest> resource,
            string modelId,
            TRequest request
        ) where TModel : ModelBase
            where TRequest : Request
        {
            return await resource.Requester.Request<TRequest, TModel>(
                resource.Endpoint,
                "PATCH",
                $"{resource.BasePath}/{modelId}",
                request
            );
        }
    }
}