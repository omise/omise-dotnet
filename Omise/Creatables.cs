using Omise.Models;
using System.Collections.Generic;
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

        public static async Task<TModel> Create<TModel, TRequest>(
            this ICreatable<TModel, TRequest> resource,
            TRequest request,
            IDictionary<string, string> customHeaders
        ) where TModel : ModelBase
            where TRequest : Request
        {
            return await resource.Requester.Request<TRequest, TModel>(
                resource.Endpoint,
                "POST",
                resource.BasePath,
                request,
                customHeaders
            );
        }
    }
}

