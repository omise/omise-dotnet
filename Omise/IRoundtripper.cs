using System.Net.Http;
using System.Threading.Tasks;

namespace Omise
{
    public interface IRoundtripper
    {
        HttpRequestMessage CreateRequest(string method, string uri);
        Task<HttpResponseMessage> Roundtrip(HttpRequestMessage request);
    }
}