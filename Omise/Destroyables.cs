using Omise.Models;
using System.Threading.Tasks;

namespace Omise {
    public interface IDestroyable<TModel> : IResource<TModel> where TModel : ModelBase {
    }

    public static class Destroyables {
        public static async Task<TModel> Destroy<TModel>(
            this IDestroyable<TModel> resource,
            string modelId
        ) where TModel : ModelBase {
            return await resource.Requester.Request<TModel>(
                resource.Endpoint,
                "DELETE",
                $"{resource.BasePath}/{modelId}"
            );
        }
    }
}