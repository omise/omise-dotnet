using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Omise.Models;

namespace Omise {
    public interface IListable<TModel> : IResource<TModel>
        where TModel: ModelBase {
    }

    public static class Listables {
        public static async Task<IList<TResult>> GetList<TResult>(
            this IListable<TResult> resource,
            int? offset = null,
            int? limit = null,
            DateTime? from = null,
            DateTime? to = null,
            Ordering ordering = null
        ) where TResult: ModelBase {

            var options = new Dictionary<string, string>();
            if (offset.HasValue) options["offset"] = offset.Value.ToString();
            if (limit.HasValue) options["limit"] = limit.Value.ToString();
            if (from.HasValue) options["from"] = Serializer.EncodeFormValue(from.Value);
            if (to.HasValue) options["to"] = Serializer.EncodeFormValue(to.Value);
            if (ordering != null) options["ordering"] = ordering.ToString();

            var path = resource.BasePath;
            if (options.Count > 0) {
                path = path + "?" + options
                    .Aggregate("", (acc, pair) => acc + "&" + pair.Key + "=" + pair.Value)
                    .TrimStart('&');
            }

            // TODO: Actual list container type that can be re-requested and supports paging as well.
            return await resource.Requester.Request<List<TResult>>(
                resource.Endpoint,
                "GET",
                path
            );
        }
    }
}

