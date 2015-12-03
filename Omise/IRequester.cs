using System.Net;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace Omise {

    public interface IRequester {
        Task<TResult> Request<TResult>(
            Endpoint endpoint,
            string method,
            string path)
            where TResult: class;

        Task<TResult> Request<TPayload, TResult>(
            Endpoint endpoint,
            string method,
            string path,
            TPayload payload)
            where TPayload: class
            where TResult: class;
    }
}

