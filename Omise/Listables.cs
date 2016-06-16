using System;
using System.Threading.Tasks;
using Omise.Models;

namespace Omise {
    public interface IListable<TModel> : IResource<TModel>
        where TModel : ModelBase {
    }

    public static class Listables {
        static readonly Serializer serializer = new Serializer();

        public class ListOptions {
            public int? Offset { get; internal set; }
            public int? Limit { get; internal set; }
            public DateTime? From { get; internal set; }
            public DateTime? To { get; internal set; }
            public Ordering? Order { get; internal set; }

            public bool IsEmpty() {
                return Offset == null &&
                Limit == null &&
                From == null &&
                To == null &&
                Order == null;
            }
        }

        public static async Task<ScopedList<TResult>> GetList<TResult>(
            this IListable<TResult> resource,
            int? offset = null,
            int? limit = null,
            DateTime? from = null,
            DateTime? to = null,
            Ordering? order = null
        ) where TResult : ModelBase {

            var opts = new ListOptions {
                Offset = offset,
                Limit = limit,
                From = from,
                To = to,
                Order = order
            };

            var path = resource.BasePath;
            if (!opts.IsEmpty()) {
                var content = serializer.ExtractFormValues(opts);
                path += $"?{await content.ReadAsStringAsync()}";
            }

            // TODO: Actual list container type that can be re-requested and supports paging as well.
            return await resource.Requester.Request<ScopedList<TResult>>(
                resource.Endpoint,
                "GET",
                path
            );
        }
    }
}