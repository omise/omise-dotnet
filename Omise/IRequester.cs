using System.Threading.Tasks;

namespace Omise
{
    public interface IRequester
    {
        string APIVersion { get; set; }

        Task<TResult> Request<TResult>(
            Endpoint endpoint,
            string method,
            string path)
            where TResult : class;

        Task<TResult> Request<TPayload, TResult>(
            Endpoint endpoint,
            string method,
            string path,
            TPayload payload)
            where TPayload : class
            where TResult : class;
    }
}