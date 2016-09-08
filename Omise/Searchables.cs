using System.Collections.Generic;
using System.Threading.Tasks;
using Omise.Models;

namespace Omise {
    public interface ISearchable<TModel> : IResource<TModel> where TModel : ModelBase {
        SearchScope Scope { get; }
    }

    public static class Searchables {
        static readonly Serializer serializer = new Serializer();

        // TODO: DRY with Listables.ListOptions
        public class SearchOptions {
            public SearchScope? Scope { get; internal set; }
            public string Query { get; internal set; }
            public IDictionary<string, string> Filters { get; internal set; }
            public Ordering? Order { get; internal set; }

            public bool IsEmpty() {
                return Scope == null &&
                    Query == null &&
                    Filters == null &&
                    Order == null;
            }
        }

        public static async Task<SearchResult<TResult>> Search<TResult>(
            this ISearchable<TResult> resource,
            string query = null,
            IDictionary<string, string> filters = null,
            Ordering? order = null
        ) where TResult : ModelBase {

            var opts = new SearchOptions {
                Scope = resource.Scope,
                Query = query,
                Filters = filters,
                Order = order,
            };

            var path = "/search";
            if (!opts.IsEmpty()) {
                var content = serializer.ExtractFormValues(opts);
                path += $"?{await content.ReadAsStringAsync()}";
            }

            return await resource.Requester.Request<SearchResult<TResult>>(
                resource.Endpoint,
                "GET",
                path
            );
        }
    }
}