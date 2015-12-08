using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources {
    public interface IListable<TModel> : IResource<TModel>
        where TModel: ModelBase {
    }

    public static class Listables {
        public static async Task<IList<TResult>> GetList<TResult>(
            this IListable<TResult> resource
            // TODO: Paging options.
        ) where TResult: ModelBase {
            // TODO: Actual list container type that can be re-requested and supports paging as well.
            return await resource.Requester.Request<List<TResult>>(
                resource.Endpoint,
                "GET",
                resource.BasePath
            );
        }

        public static async Task<TResult> Get<TResult>(
            this IListable<TResult> resource,
            string modelId
        ) where TResult: ModelBase {
            return await resource.Requester.Request<TResult>(
                resource.Endpoint,
                "GET",
                resource.BasePath + "/" + Uri.EscapeUriString(modelId)
            );
        }
    }
}

