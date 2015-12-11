using System.Net;
using System.Threading.Tasks;
using System.Net.Http;

namespace Omise {
    public interface IRoundtripper {
        HttpRequestMessage CreateRequest(string method, string uri);
        Task<HttpResponseMessage> Roundtrip(HttpRequestMessage request);
    }
}

