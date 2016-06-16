using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Omise.Tests.Util {
    public class MockRequester : IRequester {
        readonly IList<RequestAttempt> requestAttempts;

        public object ResponseObject { get; set; }
        public IList<RequestAttempt> Requests {
            get { return new ReadOnlyCollection<RequestAttempt>(requestAttempts); }
        }

        public RequestAttempt LastRequest {
            get { return requestAttempts.Last(); }
        }

        public MockRequester() {
            requestAttempts = new List<RequestAttempt>();
        }

        public async Task<TResult> Request<TResult>(
            Endpoint endpoint,
            string method,
            string path) where TResult : class {
            return await Request<object, TResult>(endpoint, method, path, null);
        }

        public Task<TResult> Request<TPayload, TResult>(
            Endpoint endpoint,
            string method,
            string path,
            TPayload payload
        ) where TPayload : class where TResult : class {
            requestAttempts.Add(new RequestAttempt {
                Endpoint = endpoint,
                Method = method,
                Path = path,
                PayloadType = typeof(TPayload),
                ResultType = typeof(TResult),
                Payload = payload,
                Result = ResponseObject,
            });

            var source = new TaskCompletionSource<TResult>();
            source.SetResult((TResult)ResponseObject);
            return source.Task;
        }
    }
}

